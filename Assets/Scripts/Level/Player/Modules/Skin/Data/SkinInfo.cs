using System;
using Tools.MaxCore.Tools.SerializableComponent;
using UnityEngine;

namespace Level.Player.Modules.Skin
{
    [Serializable]
    public class SkinInfo
    {
        public SerializableDictionary<PlayerSkinElement, Sprite> Map;
    }
}