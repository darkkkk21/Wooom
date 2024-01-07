using System;
using Tools.MaxCore.Tools.SerializableComponent;
using UnityEngine;

namespace Level.Player.Modules.Skin
{
    [Serializable]
    public class CharacterSkins
    {
        public SerializableDictionary<int, SkinInfo> CharacterLevelMap;
        public SerializableDictionary<int, ParticleSystem> CharacterEffectsMap;
        
    }
}