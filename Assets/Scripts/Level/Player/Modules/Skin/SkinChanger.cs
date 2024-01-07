using System;
using System.Collections.Generic;
using Tools.MaxCore.Tools.SerializableComponent;
using UnityEngine;

namespace Level.Player.Modules.Skin
{
    public class SkinChanger : MonoBehaviour
    {
        [SerializeField] private SettingsCharacterSkin SettingsSkins;
        [SerializeField] private Transform _resource;

        private Dictionary<PlayerSkinElement, SkinElement> skinElementMap;
        
        public void Initialize()
        {
            skinElementMap = new Dictionary<PlayerSkinElement, SkinElement>();
            var allElements = _resource.GetComponentsInChildren<SkinElement>();

            foreach (var skinElement in allElements)
            {
                skinElementMap.Add(skinElement.TargetSkin, skinElement);
            }
        }
        
        public void SetSkin(int characterId, int targetLevelCharacter)
        {
            var characterSkin = SettingsSkins.Skins[characterId].CharacterLevelMap[targetLevelCharacter];

            foreach (var key in skinElementMap.Keys)
            {
                var skin = characterSkin.Map[key];
                
                if (skin != null)
                {
                    skinElementMap[key].SetElement(skin);
                }
            }
        }
    }
}