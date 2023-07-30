using System;
using UnityEngine;

namespace Game.Scripts.Runtime.Feature.UIViews.Shop
{
    [Serializable]
    public class ItemInfo
    {
        public Sprite Skin;
        public int Count;

        public int ID { get; set; }
        public bool IsPurchased { get; set; }
        public bool IsCanPurchased { get; set; }
        public bool IsSelected { get; set; }
    }
}