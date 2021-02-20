//Copyright(c)2020 Procedural Worlds Pty Limited 
using System;
using System.Collections.Generic;
using UnityEngine;
namespace GeNa.Core
{
    /// <summary>
    /// Spline Extension for creating Rivers along a Spline
    /// </summary>
    [Serializable]
    [CreateAssetMenu(fileName = "Rivers", menuName = "Procedural Worlds/GeNa/Extensions/Rivers", order = 4)]
    public class GeNaRiverExtension : GeNaSplineExtension
    {
        [SerializeField] protected GeNaRiverProfile m_riverProfile;
        [SerializeField] protected bool m_syncToWeather = false;
        [SerializeField] protected float m_startFlow = 0.2f;
        [SerializeField] protected float m_vertexDistance = 3.0f;
        [SerializeField] protected float m_bankOverstep = 1.0f;
        [SerializeField] protected float m_splineSmoothing = 0.82f;
        [SerializeField] protected float m_riverWidth = 20f;
        [SerializeField] protected bool m_addCollider = true;
        [SerializeField] protected bool m_raycastTerrainOnly = true;
        [SerializeField] protected string m_tag = "Untagged";
        [SerializeField] protected int m_layer = -1;
        [SerializeField] protected bool m_splitAtTerrains = true;
        [SerializeField] protected MeshRenderer m_meshRenderer;
        [NonSerialized] protected GameObject m_riverMeshParent = null;
        private static readonly string _riverMeshesGameobjectName = "RiverMeshes";
        public GeNaRiverProfile RiverProfile
        {
            get => m_riverProfile;
            set => m_riverProfile = value;
        }
        public bool SyncToWeather
        {
            get => m_syncToWeather;
            set => m_syncToWeather = value;
        }
        public float StartFlow
        {
            get => m_startFlow;
            set => m_startFlow = Mathf.Clamp(value, 0.05f, 2.0f);
        }
        public float VertexDistance
        {
            get => m_vertexDistance;
            set => m_vertexDistance = value;
        }
        public float BankOverstep
        {
            get => m_bankOverstep;
            set => m_bankOverstep = Mathf.Clamp(value, 0.5f, 5.0f);
        }
        public float RiverWidth
        {
            get => m_riverWidth;
            set => m_riverWidth = Mathf.Max(value, 0.5f);
        }
        public bool AddCollider
        {
            get => m_addCollider;
            set => m_addCollider = value;
        }
        public bool RaycastTerrainOnly
        {
            get => m_raycastTerrainOnly;
            set => m_raycastTerrainOnly = value;
        }
        public string Tag
        {
            get => m_tag;
            set => m_tag = value;
        }
        public int Layer
        {
            get => m_layer;
            set => m_layer = value;
        }
        public bool SplitAtTerrains
        {
            get { return m_splitAtTerrains; }
            set { m_splitAtTerrains = value; }
        }
        public MeshRenderer MeshRenderer
        {
            get => m_meshRenderer;
            set => m_meshRenderer = value;
        }
        public GameObject Parent
        {
            get => m_riverMeshParent;
            set => m_riverMeshParent = value;
        }
        /// <summary>
        /// GeNa Extension Methods
        /// </summary>
        #region GeNaSpline Extension Methods
        protected  override void OnAttach(GeNaSpline spline)
        {
            if (RiverProfile == null)
            {
                RiverProfile = Resources.Load<GeNaRiverProfile>("River Profiles/GeNa River Profile Green");
                if (m_layer < 0)
                {
                    m_layer = LayerMask.NameToLayer("PW_Object_Large");
                    if (m_layer < 0)
                        m_layer = 0;
                }
            }
        }
        protected  override GameObject OnBake(GeNaSpline spline)
        {
            PreExecute();
            Execute();
            GameObject riverMeshes = GeNaEvents.BakeSpline(m_riverMeshParent, spline);
            if (m_splitAtTerrains && riverMeshes != null)
                GeNaRiverMesh.PostProcess(riverMeshes);
            return riverMeshes;
        }
        public override void Execute()
        {
            if (IsActive && Spline.Nodes.Count > 1)
            {
                ProcessSpline(Spline);
            }
        }
        public override void PreExecute()
        {
            //DeleteRiverMeshGameobjects(Spline);
        }
        protected  override void OnActivate()
        {
            if (Spline.Nodes.Count > 1)
                ProcessSpline(Spline);
        }
        protected  override void OnDeactivate()
        {
            DeleteRiverMeshGameobjects(Spline);
        }
        protected  override void OnDelete()
        {
            DeleteRiverMeshGameobjects(Spline);
        }
        protected  override void OnDrawGizmosSelected()
        {
            if (Spline.Settings.Advanced.DebuggingEnabled == false)
                return;
            foreach (GeNaCurve curve in Spline.Curves)
            {
                DrawCurveInfo(curve);
            }
        }
        private void DrawCurveInfo(GeNaCurve geNaCurve)
        {
            // Draw arrows showing which direction a curve is facing (from StartNode to EndNode).
            Gizmos.color = Color.red;
            GeNaSample geNaSample = geNaCurve.GetSample(0.45f);
            DrawArrow(geNaSample.Location, geNaSample.Forward);
            geNaSample = geNaCurve.GetSample(0.5f);
            DrawArrow(geNaSample.Location, geNaSample.Forward);
            geNaSample = geNaCurve.GetSample(0.55f);
            DrawArrow(geNaSample.Location, geNaSample.Forward);
        }
        private void DrawArrow(Vector3 position, Vector3 direction)
        {
            direction.Normalize();
            Vector3 right = Vector3.Cross(Vector3.up, direction).normalized;
            Ray ray = new Ray(position, (-direction + right) * 0.5f);
            Gizmos.DrawRay(ray);
            ray.direction = (-direction - right) * 0.5f;
            Gizmos.DrawRay(ray);
        }
        #endregion End GeNa Extension Methods
        private void DeleteRiverMeshGameobjects(GeNaSpline spline)
        {
            // Check to make sure they haven't move the road meshes in the hierarchy
            if (m_riverMeshParent != null && m_riverMeshParent.transform.parent != Spline.transform)
                m_riverMeshParent = null;
            if (m_riverMeshParent == null)
            {
                Transform splineTransform = Spline.gameObject.transform;
                // see if we can find it
                Transform riverMeshesTransform = splineTransform.Find(_riverMeshesGameobjectName);
                if (riverMeshesTransform != null)
                    m_riverMeshParent = riverMeshesTransform.gameObject;
            }
            if (m_riverMeshParent != null)
            {
                GameObject.DestroyImmediate(m_riverMeshParent);
                m_riverMeshParent = null;
            }
        }
        private void ProcessSpline(GeNaSpline spline)
        {
            CreateRivers();
        }
        public void UpdateMaterial()
        {
            if (RiverProfile == null)
            {
                return;
            }
            if (m_meshRenderer == null)
            {
                m_meshRenderer = Spline.gameObject.GetComponentInChildren<MeshRenderer>();
            }
            if (m_meshRenderer != null)
            {
                m_meshRenderer.sharedMaterial = RiverProfile.ApplyProfile();
            }
        }
        public void SetSplineToDownhill()
        {
            if (Spline == null)
                return;
            _SetSplineToDownhill();
        }
        private void _SetSplineToDownhill()
        {
            Dictionary<int, List<GeNaCurve>> trees = Spline.GetTrees();
            foreach (List<GeNaCurve> curCurves in trees.Values)
            {
                (float min, float max) minMax = _GetCurvesMinMax(curCurves);
                List<GeNaCurve> curves = new List<GeNaCurve>(curCurves);
                if (minMax.min > minMax.max)
                {
                    curves.Reverse();
                    (minMax.min, minMax.max) = (minMax.max, minMax.min);
                }
                float curHeight = minMax.max;
                for (int i = 0; i < curves.Count; i++)
                {
                    if (curves[i].EndNode.Position.y >= curHeight)
                    {
                        Vector3 pos = curves[i].EndNode.Position;
                        pos = new Vector3(pos.x, curHeight - 0.001f, pos.z);
                        curves[i].EndNode.Position = pos;
                    }
                    curHeight = curves[i].EndNode.Position.y;
                }
            }
            Spline.Smooth();
        }
        private (float min, float max) _GetCurvesMinMax(List<GeNaCurve> curves)
        {
            return (curves[curves.Count - 1].P3.y, curves[0].P0.y);
        }
        private void CreateRivers()
        {
            if (Spline == null || Spline.Nodes.Count < 2)
                return;
            DeleteRiverMeshGameobjects(Spline);
            if (m_riverMeshParent == null)
            {
                Transform splineTransform = Spline.gameObject.transform;
                // see if we can find it
                Transform riverMeshesTransform = splineTransform.Find(_riverMeshesGameobjectName);
                if (riverMeshesTransform != null)
                    m_riverMeshParent = riverMeshesTransform.gameObject;
                if (m_riverMeshParent == null)
                {
                    m_riverMeshParent = new GameObject(_riverMeshesGameobjectName);
                    m_riverMeshParent.transform.position = Vector3.zero;
                    m_riverMeshParent.transform.parent = splineTransform;
                }
            }
            if (RiverProfile != null)
            {
                GeNaRiverMesh geNaRiverMesh = new GeNaRiverMesh(Spline, m_startFlow, m_vertexDistance, m_bankOverstep, RiverProfile.ApplyProfile(), m_riverWidth, m_syncToWeather, RiverProfile);
                float seaLevel = GeNaEvents.GetSeaLevel(25.0f);
                geNaRiverMesh.CreateMeshes(m_riverMeshParent.transform, m_addCollider, m_raycastTerrainOnly, m_tag, m_layer, seaLevel);
            }
        }
    }
}