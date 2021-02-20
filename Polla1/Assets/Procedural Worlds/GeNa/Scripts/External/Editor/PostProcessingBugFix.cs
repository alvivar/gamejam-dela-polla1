﻿using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

#if UNITY_2019_3_OR_NEWER
using UnityEngine.LowLevel;
#else
using UnityEngine.Experimental.PlayerLoop;
#endif
#if UNITY_POST_PROCESSING_STACK_V2
using UnityEngine.Rendering.PostProcessing;
#endif
[InitializeOnLoad]
public class PostProcessingBugFix
{
    private static bool m_isDirty = true;
    static PostProcessingBugFix()
    {
        EditorApplication.update += Update;
    }
    private static void Update()
    {
        if (m_isDirty)
        {
#if UNITY_POST_PROCESSING_STACK_V2
            PostProcessVolume postProcessVolume = Object.FindObjectOfType<PostProcessVolume>();
            InternalEditorUtility.SetIsInspectorExpanded(postProcessVolume, true);
            InternalEditorUtility.SetIsInspectorExpanded(postProcessVolume, false);
#endif
            m_isDirty = false;
        }
    }
}