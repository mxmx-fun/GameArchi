using System.Collections.Generic;
using UnityEngine;

namespace GameArchi.AssetSystem
{
    public class AssetRepo
    {
        Dictionary<int, Sprite> iconAssets; //id=>sprite
        Dictionary<int, GameObject> uiAssets; //id=>uiGO

        public AssetRepo()
        {
            iconAssets = new Dictionary<int, Sprite>();
            uiAssets = new Dictionary<int, GameObject>();
        }

        public void AddIconAsset(int id, Sprite sprite)
        {
            if (!iconAssets.ContainsKey(id)) {
                iconAssets.Add(id, sprite);
            }
        }

        public void AddUIAsset(int id, GameObject uiGO)
        {
            if (!uiAssets.ContainsKey(id)) {
                uiAssets.Add(id, uiGO);
            }
        }

        public Sprite GetIconAsset(int id)
        {
            if (iconAssets.ContainsKey(id)) {
                return iconAssets[id];
            }
            return null;
        }

        public GameObject GetUIAsset(int id)
        {
            if (uiAssets.ContainsKey(id)) {
                return uiAssets[id];
            }
            return null;
        }
    }
}