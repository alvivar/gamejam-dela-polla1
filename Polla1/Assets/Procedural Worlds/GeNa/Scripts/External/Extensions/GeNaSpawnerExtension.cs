﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace GeNa.Core
{
    /// <summary>
    /// Spline Extension for running GeNa Spawners along a Spline
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "Spawner", menuName = "Procedural Worlds/GeNa/Extensions/Spawner", order = 0)]
    public class GeNaSpawnerExtension : GeNaSplineExtension
    {
        #region Variables
        [SerializeField] protected SpawnerEntry m_spawnerEntry = new SpawnerEntry();
        [SerializeField] protected bool m_autoIterate = false;
        [SerializeField] protected bool m_alignToSpline = false;
        [SerializeField] protected bool m_alignChildrenToSpline = false;
        [SerializeField] protected bool m_conformToSlope = false;
        [SerializeField] protected bool m_conformChildrenToSlope = false;
        [SerializeField] protected bool m_snapToGround = false;
        [SerializeField] protected bool m_snapChildrenToGround = false;
        [SerializeField] protected bool m_useSpawnCriteria = false;
        public void Serialize()
        {
            m_spawnerEntry?.Serialize();
        }
        public void Deserialize()
        {
            m_spawnerEntry?.Deserialize();
        }
        #endregion
        #region Properties
        public SpawnerEntry SpawnerEntry => m_spawnerEntry;
        public GeNaSpawner Spawner
        {
            get => m_spawnerEntry.Spawner;
            set => m_spawnerEntry.Spawner = value;
        }
        public GeNaSpawnerData SpawnerData => m_spawnerEntry.SpawnerData;
        public Transform Target
        {
            get => m_spawnerEntry.Target;
            set => m_spawnerEntry.Target = value;
        }
        public Vector3 OffsetPosition
        {
            get => m_spawnerEntry.OffsetPosition;
            set => m_spawnerEntry.OffsetPosition = value;
        }
        public Vector3 OffsetRotation
        {
            get => m_spawnerEntry.OffsetRotation;
            set => m_spawnerEntry.OffsetRotation = value;
        }
        public float FlowRate
        {
            get => m_spawnerEntry.FlowRate;
            set => m_spawnerEntry.FlowRate = value;
        }
        public float SpawnRange
        {
            get => m_spawnerEntry.SpawnRange;
            set => m_spawnerEntry.SpawnRange = value;
        }
        public float ThrowDistance
        {
            get => m_spawnerEntry.ThrowDistance;
            set => m_spawnerEntry.ThrowDistance = value;
        }
        public List<SpawnCall> SpawnCalls
        {
            get => m_spawnerEntry.SpawnCalls;
            set => m_spawnerEntry.SpawnCalls = value;
        }
        public bool AutoIterate
        {
            get => m_autoIterate;
            set => m_autoIterate = value;
        }
        public bool AlignToSpline
        {
            get => m_alignToSpline;
            set => m_alignToSpline = value;
        }
        public bool AlignChildrenToSpline
        {
            get => m_alignChildrenToSpline;
            set => m_alignChildrenToSpline = value;
        }
        public bool ConformToSlope
        {
            get => m_conformToSlope;
            set => m_conformToSlope = value;
        }
        public bool ConformChildrenToSlope
        {
            get => m_conformChildrenToSlope;
            set => m_conformChildrenToSlope = value;
        }
        public bool SnapToGround
        {
            get => m_snapToGround;
            set => m_snapToGround = value;
        }
        public bool SnapChildrenToGround
        {
            get => m_snapChildrenToGround;
            set => m_snapChildrenToGround = value;
        }
        public bool UseSpawnCriteria
        {
            get => m_useSpawnCriteria;
            set => m_useSpawnCriteria = value;
        }
        #endregion
        protected override GameObject OnBake(GeNaSpline spline)
        {
            SpawnCalls.Clear();
            Execute();
            return null;
        }
        protected override void OnSelect()
        {
            base.OnSelect();
            if (Spawner == null)
                return;
            name = Spawner.name;
        }
        protected override void OnAttach(GeNaSpline spline)
        {
            if (SpawnerData == null)
                return;
            m_spawnerEntry.SpawnCalls = GenerateSpawnCalls(spline);
        }
        public override void PreExecute()
        {
            if (SpawnerData == null)
                return;
            Spawner.Load();
            // Generate the spawn calls
            SpawnCalls = GenerateSpawnCalls(Spline);
            name = Spawner.name;
            if (Spline != null)
            {
                GeNaSpawnerInternal.SetupTempObject(Spline.transform);
            }
        }
        public override void Execute()
        {
            if (SpawnerData == null)
                return;
            // Loop over each Spawn Call
            foreach (SpawnCall spawnCall in SpawnCalls)
            {
                // Loop over each Entity
                foreach (SpawnedEntity entity in spawnCall.GetSpawnedEntities())
                {
                    // Get Spawner from Entity
                    GeNaSpawnerData spawner = entity.SpawnerData;
                    // If there is no longer a spawner associated with Entity
                    if (spawner == null)
                        continue;
                    // If entity is not a Prefab
                    if (!entity.IsReferenced)
                        continue;
                    GameObject gameObject = entity.GameObject;
                    if (gameObject != null)
                        // Deactivate that entity
                        gameObject.SetActive(false);
                    foreach (SpawnedChild child in entity.SpawnedChildren)
                    {
                        if (child == null)
                            continue;
                        if (child.GameObject == null)
                            continue;
                        // Deactivate it
                        child.GameObject.SetActive(false);
                    }
                }
            }
            UpdateEntities();
        }
        protected override void OnDelete()
        {
            GeNaEvents.onSpawnFinished -= OnPostSpawn;
        }
        public void Spawn()
        {
            if (!Spline.HasNodes)
            {
                GeNaDebug.LogWarning($"The Spline '{Spline.name}' does not contain any nodes!");
                return;
            }
            if (SpawnerData == null)
                return;
            m_spawnerEntry.SpawnCalls = GenerateSpawnCalls(Spline);
            if (SpawnerEntry.SpawnCalls.Count == 0)
                return;
            m_spawnerEntry.RootSpawnCall = m_spawnerEntry.SpawnCalls.First();
            m_spawnerEntry.Spawner.Load();
            GeNaUtility.ScheduleSpawn(m_spawnerEntry);
            GeNaEvents.onSpawnFinished -= OnPostSpawn;
            GeNaEvents.onSpawnFinished += OnPostSpawn;
            RecordUndo("Spawn");
        }
        public void OnPostSpawn()
        {
            Serialize();
            PreExecute();
            Execute();
        }
        public void RecordUndo(string description)
        {
            Spline.RecordUndo(description, Undo);
        }
        public void Undo()
        {
            GeNaSpawnerInternal.Undo(m_spawnerEntry.SpawnerData);
        }
        public void Iterate()
        {
            if (SpawnerData == null)
                return;
            Undo();
            Spawn();
            GeNaEvents.onSpawnFinished -= OnPostSpawn;
            GeNaEvents.onSpawnFinished += OnPostSpawn;
        }
        public void UpdateEntities()
        {
            if (SpawnerData == null)
                return;
            // Loop over each spawned entity Dictionary
            foreach (SpawnCall spawnCall in SpawnCalls)
            {
                if (spawnCall.IsActive)
                {
                    spawnCall.AlignToRotation = m_alignToSpline;
                    spawnCall.AlignChildrenToRotation = m_alignChildrenToSpline;
                    spawnCall.ConformToSlope = m_conformToSlope;
                    spawnCall.ConformChildrenToSlope = m_conformChildrenToSlope;
                    spawnCall.SnapToGround = m_snapToGround;
                    spawnCall.SnapChildrenToGround = m_snapChildrenToGround;
                    spawnCall.UseSpawnCriteria = m_useSpawnCriteria;
                    spawnCall.UpdateEntities();
                }
                else
                    spawnCall.DisableEntities();
            }
        }
        public List<SpawnCall> GenerateSpawnCalls(GeNaSpline spline)
        {
            if (FlowRate <= 0.0f)
                return new List<SpawnCall>();
            List<GeNaNode> nodes = spline.Nodes;
            float length = spline.Length;
            int spawnCallCount = Mathf.CeilToInt(length / FlowRate);
            List<SpawnCall> result = new List<SpawnCall>(spawnCallCount);
            if (nodes.Count == 0)
                return result;
            Transform spawnParent = default;
            Transform groundObject = default;
            if (SpawnerData != null)
            {
                // If the spawner has GameObjects
                if (SpawnerData.HasGameObjectProtos)
                    spawnParent = SpawnerData.SpawnParent;
                // Sample ground at location
                if (GeNaSpawnerInternal.Sample(SpawnerData, nodes.First().Position, out RaycastHit hitInfo))
                    groundObject = hitInfo.transform;
            }
            float distance = 0f;
            int index = 0;
            while (distance < length)
            {
                // Collect Sample at Distance
                GeNaSample geNaSample = spline.GetSampleAtDistance(distance);
                if (geNaSample != null)
                {
                    // Offset Location & Rotation
                    Vector3 location = geNaSample.Location + geNaSample.Scale.x * OffsetPosition.x * geNaSample.Right;
                    Vector3 rotation = new Vector3(0f, OffsetRotation.y, 0f);
                    // Align to Spline Mode?
                    if (AlignToSpline)
                    {
                        Quaternion forwardRotation = Quaternion.LookRotation(geNaSample.Forward, Vector3.up);
                        Vector3 euler = forwardRotation.eulerAngles;
                        euler.x = euler.z = 0f;
                        euler.y += OffsetRotation.y;
                        rotation = euler;
                    }
                    // Sample ground at location
                    if (SpawnerData != null)
                        if (GeNaSpawnerInternal.DetectGroundAll(SpawnerData, location, out RaycastHit hitInfo))
                            groundObject = hitInfo.transform;
                    SpawnCall spawnCall = default;
                    if (index < SpawnCalls.Count)
                    {
                        spawnCall = SpawnCalls[index++];
                        // if (spawnCall.IsEmpty || !spawnCall.Generated)
                        //     spawnCall = null;
                    }
                    if (spawnCall == null)
                    {
                        // Generate Spawn Call for entry
                        spawnCall = new SpawnCall(SpawnerData)
                        {
                            Normal = Vector3.up
                        };
                    }
                    spawnCall.Spawner = SpawnerData;
                    spawnCall.SetParent(spawnParent);
                    spawnCall.SetTarget(groundObject);
                    spawnCall.SpawnedLocation = location;
                    spawnCall.GeNaSample = geNaSample;
                    spawnCall.SpawnDistance = distance;
                    spawnCall.SpawnRange = SpawnRange;
                    spawnCall.FlowRate = FlowRate;
                    spawnCall.Location = location;
                    spawnCall.Rotation = rotation;
                    spawnCall.IsActive = true;
                    GeNaSpawnerInternal.GenerateAabbTest(SpawnerData, out AabbTest aabbTest, location);
                    GeNaSpawnerInternal.SetSpawnOrigin(SpawnerData, spawnCall);
                    spawnCall.CanSpawn = GeNaSpawnerInternal.CheckLocationForSpawn(SpawnerData, aabbTest);
                    result.Add(spawnCall);
                }
                // Offset Distance for next iteration
                distance += FlowRate;
            }
            for (int i = index; i < SpawnCalls.Count; i++)
            {
                SpawnCall spawnCall = SpawnCalls[i];
                spawnCall.IsActive = false;
                spawnCall.DisableEntities();
                result.Add(spawnCall);
            }
            if (SpawnerData != null)
                GeNaSpawnerInternal.GenerateRandomData(SpawnerData, result);
            return result;
        }
    }
}