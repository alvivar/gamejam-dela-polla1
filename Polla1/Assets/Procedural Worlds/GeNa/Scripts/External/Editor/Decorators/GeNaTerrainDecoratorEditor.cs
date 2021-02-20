using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace GeNa.Core
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GeNaTerrainDecorator))]
    public class GeNaTerrainDecoratorEditor : GeNaDecoratorEditor<GeNaTerrainDecorator>
    {
        [MenuItem("GameObject/GeNa/Decorators/Terrain Decorator")]
        public static void AddDecorator(MenuCommand command)
        {
            GameObject gameObject = command.context as GameObject;
            if (gameObject != null)
            {
                GeNaTerrainDecorator decorator = gameObject.AddComponent<GeNaTerrainDecorator>();
                GeNaDecoratorEditorUtility.RegisterDecorator(gameObject, decorator);
            }
        }
        protected GeNaTerrainDecorator[] m_tree;
        protected TerrainTools m_terrainTools;
        public TerrainTools TerrainTools
        {
            get
            {
                if (m_terrainTools == null)
                {
                    GeNaManager gm = GeNaManager.GetInstance();
                    m_terrainTools = gm.TerrainTools;
                }
                return m_terrainTools;
            }
        }
        protected void SelectTree(bool isSelected)
        {
            Transform transform = Decorator.transform;
            Transform root = transform.root;
            m_tree = root.GetComponentsInChildren<GeNaTerrainDecorator>();
            foreach (GeNaTerrainDecorator tree in m_tree)
                tree.IsSelected = isSelected;
        }
        protected override void OnEnable()
        {
            base.OnEnable();
            if (Decorator == null)
            {
                return;
            }
            SelectTree(true);
            SceneView.duringSceneGui += SceneGUI;
        }
        private void OnDisable()
        {
            if (Decorator == null)
            {
                return;
            }
            SelectTree(false);
            TerrainTools.Dispose();
            SceneView.duringSceneGui -= SceneGUI;
        }
        public override void OnSceneGUI()
        {
            if (Decorator == null)
            {
                return;
            }
            Transform transform = Decorator.transform;
            TerrainModifier terrainModifier = Decorator.TerrainModifier;
            float radius = terrainModifier.AreaOfEffect * .5f;
            Vector3 center = transform.position;
            Vector3 size = new Vector3(radius, 0f, radius);
            Matrix4x4 oldMatrix = Handles.matrix;
            Handles.matrix = Matrix4x4.TRS(center, transform.rotation, Vector3.one);
            Handles.DrawWireCube(Vector3.zero, size);
            Handles.matrix = oldMatrix;
            TerrainTools.Visualize(Decorator.TerrainModifier);
        }
        public void SceneGUI(SceneView scene)
        {
        }
        protected override void RenderPanel(bool helpEnabled)
        {
            EditorGUI.BeginChangeCheck();
            {
                EditorUtils.TerrainModifier(Decorator.TerrainModifier, helpEnabled);
            }
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(Decorator);
                foreach (Object o in targets)
                {
                    GeNaTerrainDecorator decorator = (GeNaTerrainDecorator) o;
                    decorator.TerrainModifier.CopyFrom(Decorator.TerrainModifier);
                }
            }
        }
    }
}