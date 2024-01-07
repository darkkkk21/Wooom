using Tools.MaxCore.Tools.SerializableComponent;
using UnityEngine;

namespace Level.Player.Modules.Skin
{
    [CreateAssetMenu(menuName = "Game/Character/Skins", fileName = "SettingsCharacterSkin")]
    public class SettingsCharacterSkin : ScriptableObject
    {
        public SerializableDictionary<int, CharacterSkins> Skins;
    }
}