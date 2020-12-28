using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

public class ShowInfoWindow : EditorWindow
{


    public static int defaultSpaceBefore = 10;
    public static int defaultHeight = 2;
    public static int defaultSpaceAfter = 5;
    public static int defaultWidth = 10;
    public static int defaultInnerWidth = 15;

    public static TextAnchor defaultAnchor = TextAnchor.LowerLeft;
    public static FontStyle defaultStyle = FontStyle.BoldAndItalic;

    public static Object font;

    public static int defaultSize = 12;
    public static bool boxEnabled = true;

    public static ShowInfoColor defaultColor = ShowInfoColor.Black;
    public static ShowInfoColor defaultBoxColor = ShowInfoColor.White;


    public string sample = "Sample Text";


    [MenuItem("Window/Show Info Window")]
    public static void ShowWindow()
    {
        GetWindow<ShowInfoWindow>("Show Info Window");
    }

    //

    void OnGUI()
    {

        GUILayout.Label("Set the configuration for your custom Text Hint.");


        EditorGUILayout.Space();

        if (defaultSize < 10) defaultSize = 10;
        if (defaultSize > 100) defaultSize = 100;

        defaultSpaceBefore = EditorGUILayout.IntField("Space Before", defaultSpaceBefore);
        if (defaultSpaceBefore < -2) defaultSpaceBefore = -2;
        if (defaultSpaceBefore > 100) defaultSpaceBefore = 100;

        defaultHeight = EditorGUILayout.IntField("Height", defaultHeight);
        if (defaultHeight < -10) defaultHeight = -10;
        if (defaultHeight > 100) defaultHeight = 100;

        defaultSpaceAfter = EditorGUILayout.IntField("Space After", defaultSpaceAfter);
        if (defaultSpaceAfter < 0) defaultSpaceAfter = 0;
        if (defaultSpaceAfter > 100) defaultSpaceAfter = 100;

        EditorGUILayout.Space();

        defaultWidth = EditorGUILayout.IntField("Width", defaultWidth);
        if (defaultWidth < 0) defaultWidth = 0;
        if (defaultWidth > 100) defaultWidth = 100;

        defaultInnerWidth = EditorGUILayout.IntField("Inner Width", defaultInnerWidth);
        if (defaultInnerWidth < -50) defaultInnerWidth = -50;
        if (defaultInnerWidth > 100) defaultInnerWidth = 100;

        EditorGUILayout.Space();

        defaultAnchor = (TextAnchor)EditorGUILayout.EnumPopup("Anchor", defaultAnchor);
        defaultStyle = (FontStyle)EditorGUILayout.EnumPopup("Style", defaultStyle);

        font = EditorGUILayout.ObjectField(font, typeof(Font), false);

        EditorGUILayout.Space();

        defaultSize = EditorGUILayout.IntField("Text Size", defaultSize);
        boxEnabled = EditorGUILayout.Toggle("Show Box", boxEnabled);

        EditorGUILayout.Space();

        defaultColor = (ShowInfoColor)EditorGUILayout.EnumPopup("Text Color", defaultColor);
        defaultBoxColor = (ShowInfoColor)EditorGUILayout.EnumPopup("Box Color", defaultBoxColor);

        EditorGUILayout.Space();

        sample = EditorGUILayout.TextField("Hint", sample);

        ///

        Rect lr = GUILayoutUtility.GetLastRect();

        int bugFix = 20;

        if (boxEnabled)
        {
            EditorGUI.DrawRect(new Rect(lr.position.x + defaultWidth,
                lr.position.y + bugFix + defaultSpaceBefore, lr.width - defaultWidth * 2,
                lr.height + defaultHeight + 2), ShowInfoStyles.ConfigColor(defaultBoxColor));
        }

        GUIStyle style = new GUIStyle(EditorStyles.label);

        style.fontStyle = defaultStyle;
        style.alignment = defaultAnchor;
        style.fontSize = Mathf.RoundToInt(defaultSize);
        style.normal.textColor = ShowInfoStyles.ConfigColor(defaultColor);

        style.font = font as Font;

        GUI.Label(new Rect(lr.position.x + defaultWidth + defaultInnerWidth,
            lr.position.y + bugFix + defaultSpaceBefore, lr.width - defaultWidth - defaultInnerWidth,
            lr.height + defaultHeight + 2), sample, style);
        
        EditorGUILayout.Space(defaultSpaceBefore + defaultHeight + defaultSpaceAfter + bugFix - 4);

        ///

        if (GUILayout.Button("Apply"))
        {
            Save();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Clear Data"))
        {
            EditorPrefs.DeleteAll();
        }



    }



    void Save()
    {
        EditorPrefs.SetInt("StoredDefault_SpaceBefore", defaultSpaceBefore);
        EditorPrefs.SetInt("StoredDefault_Height", defaultHeight);
        EditorPrefs.SetInt("StoredDefault_SpaceAfter", defaultSpaceAfter);
        EditorPrefs.SetInt("StoredDefault_Width", defaultWidth);
        EditorPrefs.SetInt("StoredDefault_InnerWidth", defaultInnerWidth);

        ///

        EditorPrefs.SetString("StoredDefault_Anchor", defaultAnchor.ToString());
        EditorPrefs.SetString("StoredDefault_Style", defaultStyle.ToString());
        EditorPrefs.SetInt("StoredDefault_Size", defaultSize);
        EditorPrefs.SetBool("StoredDefault_Box", boxEnabled);
        EditorPrefs.SetString("StoredDefault_FontColor", defaultColor.ToString());
        EditorPrefs.SetString("StoredDefault_BoxColor", defaultBoxColor.ToString());

    }

    public static void Load()
    {
        defaultSpaceBefore = EditorPrefs.GetInt("StoredDefault_SpaceBefore", 10);
        defaultHeight = EditorPrefs.GetInt("StoredDefault_Height", 2);
        defaultSpaceAfter = EditorPrefs.GetInt("StoredDefault_SpaceAfter", 5);
        defaultWidth = EditorPrefs.GetInt("StoredDefault_Width", 10);
        defaultInnerWidth = EditorPrefs.GetInt("StoredDefault_InnerWidth", 15);

        ///

        defaultAnchor = (TextAnchor)System.Enum.Parse(typeof(TextAnchor),
            EditorPrefs.GetString("StoredDefault_Anchor", "LowerLeft"));

        defaultStyle = (FontStyle)System.Enum.Parse(typeof(FontStyle),
            EditorPrefs.GetString("StoredDefault_Style", "BoldAndItalic"));

        defaultSize = EditorPrefs.GetInt("StoredDefault_Size", 12);

        boxEnabled = EditorPrefs.GetBool("StoredDefault_Box", true);

        defaultColor = (ShowInfoColor)System.Enum.Parse(typeof(ShowInfoColor),
            EditorPrefs.GetString("StoredDefault_FontColor", "Black"));

        defaultBoxColor = (ShowInfoColor)System.Enum.Parse(typeof(ShowInfoColor),
            EditorPrefs.GetString("StoredDefault_BoxColor", "White"));

    }




}
#endif
