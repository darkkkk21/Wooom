using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Player.Modules.Skin
{
    public class SkinElement : MonoBehaviour
    {
        public PlayerSkinElement TargetSkin;
        [SerializeField] private List<SpriteRenderer> _spriteRenderer;
        
        public void SetElement(Sprite sprite) => 
            _spriteRenderer.ForEach(s => s.sprite = sprite);
    }
}