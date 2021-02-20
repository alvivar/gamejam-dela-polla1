//Copyright(c)2020 Procedural Worlds Pty Limited 
using UnityEngine;
using UnityEditor;
namespace GeNa.Core
{
    [CustomEditor(typeof(GeNaRiverExtension))]
    public class GeNaRiverExtensionEditor : GeNaSplineExtensionEditor
    {
        protected Editor m_riverProfileEditor;
        protected GeNaRiverExtension m_riverExtension;
        private void OnEnable()
        {
            if (m_editorUtils == null)
                m_editorUtils = PWApp.GetEditorUtils(this, "GeNaSplineExtensionEditor");
            m_riverExtension = target as GeNaRiverExtension;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GlobalPanel();
        }
        private void GlobalPanel()
        {
            EditorGUILayout.BeginHorizontal();
            m_editorUtils.LabelField("Tag", GUILayout.MaxWidth(40));
            m_riverExtension.Tag = EditorGUILayout.TagField(m_riverExtension.Tag);
            m_editorUtils.LabelField("Layer", GUILayout.MaxWidth(40));
            m_riverExtension.Layer = EditorGUILayout.LayerField(m_riverExtension.Layer);
            EditorGUILayout.EndHorizontal();
            m_editorUtils.InlineHelp("TagAndLayerHelp", HelpEnabled);
            m_riverExtension.SplitAtTerrains = m_editorUtils.Toggle("SplitMeshesAtTerrains", m_riverExtension.SplitAtTerrains, HelpEnabled);
            m_riverExtension.AddCollider = m_editorUtils.Toggle("AddCollider", m_riverExtension.AddCollider, HelpEnabled);
            m_riverExtension.RaycastTerrainOnly = m_editorUtils.Toggle("RaycastTerrainOnly", m_riverExtension.RaycastTerrainOnly, HelpEnabled);
            m_riverExtension.RiverWidth = m_editorUtils.FloatField("RiverWidth", m_riverExtension.RiverWidth, HelpEnabled);
            m_riverExtension.StartFlow = m_editorUtils.FloatField("StartFlow", m_riverExtension.StartFlow, HelpEnabled);
            m_riverExtension.BankOverstep = m_editorUtils.FloatField("BankOverstep", m_riverExtension.BankOverstep, HelpEnabled);
            m_riverExtension.VertexDistance = m_editorUtils.Slider("VertexDistance", m_riverExtension.VertexDistance, 1.5f, 5.0f, HelpEnabled);
            m_riverExtension.RiverProfile = (GeNaRiverProfile) m_editorUtils.ObjectField("RiverProfile", m_riverExtension.RiverProfile, typeof(GeNaRiverProfile), false, HelpEnabled);
            if (m_riverExtension.RiverProfile != null)
            {
                m_riverExtension.SyncToWeather = m_editorUtils.Toggle("SyncToWeather", m_riverExtension.SyncToWeather, HelpEnabled);
                if (m_riverProfileEditor == null)
                    m_riverProfileEditor = CreateEditor(m_riverExtension.RiverProfile);
                GeNaRiverProfileEditor.SetProfile(m_riverExtension.RiverProfile, (GeNaRiverProfileEditor) m_riverProfileEditor);
                EditorGUI.BeginChangeCheck();
                m_riverProfileEditor.OnInspectorGUI();
                if (EditorGUI.EndChangeCheck())
                    m_riverExtension.UpdateMaterial();
            }
            if (m_editorUtils.Button("MakeSplineDownhill", HelpEnabled))
                m_riverExtension.SetSplineToDownhill();
            if (m_editorUtils.Button("BakeRiver", HelpEnabled))
                if (EditorUtility.DisplayDialog(m_editorUtils.GetTextValue("BakeTitleRiver"), m_editorUtils.GetTextValue("BakeMessageRiver"), "Yes", "No"))
                    m_riverExtension.Bake();
        }
    }
}