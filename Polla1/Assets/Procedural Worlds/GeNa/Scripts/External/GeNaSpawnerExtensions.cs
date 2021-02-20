using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace GeNa.Core
{
    public static class GeNaSpawnerExtensions
    {
        #region TEMP - Saving References Recursively is very temporary
        public static void AddBrushTexture(this Resource resource, Texture2D texture)
        {
            resource.AddBrushTexture(texture, resource.Palette);
        }
        public static void AddBrushTexture(this Resource resource, Texture2D texture, Palette palette)
        {
            //TODO : Manny : Add Brush Texture shouldn't be an internal method (should be an extension)
            bool emptySet = resource.BrushTextures == null || resource.BrushTextures.Count < 1;
            // Using a set to avoid duplications
            HashSet<Texture2D> set = emptySet ? new HashSet<Texture2D>() : new HashSet<Texture2D>(resource.BrushTextures);
#if UNITY_EDITOR
            if (texture != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(texture, out string guid, out long localID))
                {
                    int id = palette.Add(texture, guid);
                    if (palette.IsValidID(id))
                    {
                        resource.BrushTextureIDs.Add(id);
                        set.Add(texture);
                    }
                }
            }
#endif
            resource.BrushTextures = new List<Texture2D>(set);
            // Select it and update the texture if the set was empty
            if (emptySet || resource.BrushTXIndex < 0)
            {
                resource.BrushTXIndex = 0;
                resource.UpdateBrushTexture();
            }
        }
        public static void AddSpawner(this Prototype prototype, GeNaSpawner spawner, Palette palette)
        {
#if UNITY_EDITOR
            GameObject gameObject = spawner.gameObject;
            if (gameObject != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(gameObject, out string guid, out long localID))
                {
                    int id = palette.Add(gameObject, guid);
                    if (palette.IsValidID(id))
                        prototype.SpawnerPaletteID = id;
                }
            }
#endif
            // prototype.LoadReferences(palette);
        }
        public static void AddPrefab(this Resource resource, GameObject prefab, Palette palette)
        {
#if UNITY_EDITOR
            if (prefab != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(prefab, out string guid, out long localID))
                {
                    int id = palette.Add(prefab, guid);
                    if (palette.IsValidID(id))
                    {
                        resource.AssetID = guid;
                        resource.PrefabPaletteID = id;
                        resource.Prefab = prefab;
                    }
                }
            }
#endif
            // resource.LoadReferences(palette);
        }
        public static void AddSubSpawner(this Resource resource, GameObject subSpawnerPrefab, Palette palette)
        {
#if UNITY_EDITOR
            if (subSpawnerPrefab != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(subSpawnerPrefab, out string guid, out long localID))
                {
                    int id = palette.Add(subSpawnerPrefab, guid);
                    if (palette.IsValidID(id))
                    {
                        resource.SubSpawnerPaletteID = id;
                        GeNaSpawner subSpawner = subSpawnerPrefab.GetComponent<GeNaSpawner>();
                        if (subSpawner != null)
                        {
                            subSpawner.Deserialize();
                            resource.SubSpawnerData = subSpawner.SpawnerData;
                            //subSpawner.LoadAllReferences();
                        }
                    }
                }
            }
#endif
            // resource.LoadReferences(palette);
        }
        public static void AddMaskImage(this SpawnCriteria spawnCriteria, Texture2D maskImage, Palette palette)
        {
#if UNITY_EDITOR
            if (maskImage != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(maskImage, out string guid, out long loclaId))
                {
                    int id = palette.Add(maskImage, guid);
                    if (palette.IsValidID(id))
                    {
                        spawnCriteria.MaskImagePaletteID = id;
                        spawnCriteria.MaskImage = maskImage;
                    }
                }
            }
#endif
            // spawnCriteria.LoadReferences(palette);
        }
        public static void AddDetailPrototype(this Resource resource, GameObject gameObject, Palette palette)
        {
#if UNITY_EDITOR
            if (gameObject != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(gameObject, out string guid, out long localId))
                {
                    int id = palette.Add(gameObject, guid);
                    if (palette.IsValidID(id))
                    {
                        resource.AssetID = guid;
                        resource.DetailPrototypeData.prototypeGameObjectPaletteID = id;
                        resource.DetailPrototypeData.prototype = gameObject;
                    }
                }
            }
#endif
            // terrainDetailPrototypeData.LoadReferences(palette);
        }
        public static void AddDetailPrototype(this Resource resource, Texture2D texture2D, Palette palette)
        {
#if UNITY_EDITOR
            if (texture2D != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(texture2D, out string guid, out long localId))
                {
                    int id = palette.Add(texture2D, guid);
                    if (palette.IsValidID(id))
                    {
                        resource.AssetID = guid;
                        resource.DetailPrototypeData.prototypeTexturePaletteID = id;
                        resource.DetailPrototypeData.prototypeTexture = texture2D;
                    }
                }
            }
#endif
            // terrainDetailPrototypeData.LoadReferences(palette);
        }
        public static void AddTerrainLayerAsset(this Resource resource, Texture2D terrainTexture2D, Palette palette)
        {
#if UNITY_EDITOR
            if (terrainTexture2D != null)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(terrainTexture2D, out string guid, out long localId))
                {
                    int id = palette.Add(terrainTexture2D, guid);
                    if (palette.IsValidID(id))
                    {
                        resource.AssetID = guid;
                        resource.TexturePrototypeData.terrainTextureAssetPaletteID = id;
                        resource.TexturePrototypeData.terrainTexture2DAsset = terrainTexture2D;
                    }
                }
            }
#endif
            // terrainTexturePrototypeData.LoadReferences(palette);
        }
        public static void AddBrushTextures(this TerrainModifier terrainModifier, List<Texture2D> brushTextures, Palette palette)
        {
#if UNITY_EDITOR
            terrainModifier.BrushTextureIDs.Clear();
            foreach (Texture2D brushTexture in brushTextures)
            {
                if (AssetDatabase.TryGetGUIDAndLocalFileIdentifier(brushTexture, out string guid, out long localID))
                {
                    int id = palette.Add(brushTexture, guid);
                    if (palette.IsValidID(id))
                    {
                        terrainModifier.BrushTextureIDs.Add(id);
                    }
                }
            }
#endif
            // terrainModifier.LoadReferences(palette);
        }
        #endregion
        public static void Load(this GeNaSpawner geNaSpawner)
        {
            geNaSpawner.Deserialize();
            geNaSpawner.Refresh();
            geNaSpawner.LoadAllReferences();
        }
        public static void Save(this GeNaSpawner geNaSpawner)
        {
            geNaSpawner.Serialize();
        }
        public static void LoadAllReferences(this GeNaSpawner geNaSpawner)
        {
            Palette palette = geNaSpawner.Palette;
            geNaSpawner.SpawnerData.LoadReferences(palette);
        }
        public static void LoadReferences(this Prototype prototype, Palette palette)
        {
            GameObject spawnerPrefab = palette.GetPrefab(prototype.SpawnerPaletteID);
            if (spawnerPrefab != null)
            {
                GeNaSpawner spawner = spawnerPrefab.GetComponent<GeNaSpawner>();
                if (spawner != null)
                {
                    prototype.SpawnerData = spawner.SpawnerData;
                }
            }
            foreach (Resource resource in prototype.GetResources())
                resource.LoadReferences(palette);
        }
        public static void LoadReferences(this Resource resource, Palette palette)
        {
            resource.Prefab = palette.GetPrefab(resource.PrefabPaletteID);
            GameObject spawnerPrefab = palette.GetPrefab(resource.SpawnerPaletteID);
            if (spawnerPrefab != null)
            {
                GeNaSpawner spawner = spawnerPrefab.GetComponent<GeNaSpawner>();
                if (spawner != null)
                {
                    spawner.Deserialize();
                    resource.SpawnerData = spawner.SpawnerData;
                }
            }
            GameObject subSpawnerPrefab = palette.GetPrefab(resource.SubSpawnerPaletteID);
            if (subSpawnerPrefab != null)
            {
                GeNaSpawner subSpawner = subSpawnerPrefab.GetComponent<GeNaSpawner>();
                if (subSpawner != null)
                {
                    subSpawner.Deserialize();
                    resource.SubSpawnerData = subSpawner.SpawnerData;
                    subSpawner.LoadAllReferences();
                }
            }
            foreach (int id in resource.BrushTextureIDs)
            {
                Texture2D texture = palette.GetTexture2D(id);
                if (texture == null)
                    continue;
                resource.BrushTextures.Add(texture);
            }
            resource.SpawnCriteria.LoadReferences(palette);
            switch (resource.Type)
            {
                case Constants.ResourceType.TerrainTexture:
                    resource.TexturePrototypeData.LoadReferences(palette);
                    break;
                case Constants.ResourceType.TerrainGrass:
                    resource.DetailPrototypeData.LoadReferences(palette);
                    break;
            }
            foreach (IDecorator decorator in resource.Decorators)
            {
                decorator.LoadReferences(palette);
            }
        }
        public static void LoadReferences(this IDecorator decorator, Palette palette)
        {
            if (decorator is GeNaTerrainDecorator terrainDecorator)
            {
                terrainDecorator.TerrainModifier.LoadReferences(palette);
            }
        }
        public static void LoadReferences(this SpawnCriteria spawnCriteria, Palette palette)
        {
            spawnCriteria.MaskImage = palette.GetTexture2D(spawnCriteria.MaskImagePaletteID);
        }
        public static void LoadReferences(this TerrainDetailPrototypeData terrainDetailPrototypeData, Palette palette)
        {
            terrainDetailPrototypeData.prototype = palette.GetPrefab(terrainDetailPrototypeData.prototypeGameObjectPaletteID);
            terrainDetailPrototypeData.prototypeTexture = palette.GetTexture2D(terrainDetailPrototypeData.prototypeTexturePaletteID);
        }
        public static void LoadReferences(this TerrainModifier terrainModifier, Palette palette)
        {
            terrainModifier.BrushTextures.Clear();
            foreach (int id in terrainModifier.BrushTextureIDs)
            {
                Texture2D texture2D = palette.GetTexture2D(id);
                if (texture2D != null)
                    terrainModifier.BrushTextures.Add(texture2D);
            }
        }
        public static void LoadReferences(this TerrainTexturePrototypeData terrainTexturePrototypeData, Palette palette)
        {
            terrainTexturePrototypeData.terrainTexture2DAsset = palette.GetTexture2D(terrainTexturePrototypeData.terrainTextureAssetPaletteID);
        }
        public static void LoadReferences(this GeNaSpawnerData spawnerData, Palette palette)
        {
            if (spawnerData.LoadedReferences)
                return;
            foreach (Prototype prototype in spawnerData.SpawnPrototypes)
                prototype.LoadReferences(palette);
            spawnerData.LoadedReferences = true;
        }
    }
}