using UnityEditor;
namespace GeNa.Core
{
    public static class ExportTextureEditor
    {
        [MenuItem("Export/Terrain Textures")]
        public static void ExportTerrainTextures()
        {
            GeNaManager gm = GeNaManager.GetInstance();
            TerrainTools tools = gm.TerrainTools;
            tools.ExportTerrainTextures();
        }
    }
}