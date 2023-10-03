using Tools.MaxCore.Tools.SerializableComponent;
using UnityEngine;

namespace Game.Scripts.Runtime.Feature.UIViews.Shop
{
    [CreateAssetMenu(menuName = "Game/Path/" + nameof(ShopItemInfoData), fileName = nameof(ShopItemInfoData))]
    public class ShopItemInfoData : ScriptableObject
    {
        public SerializableDictionary<int, ItemInfo> PathMap;
    }
}