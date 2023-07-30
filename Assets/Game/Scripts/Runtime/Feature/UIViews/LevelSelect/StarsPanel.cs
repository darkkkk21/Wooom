using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Runtime.Feature.UIViews.LevelSelect
{
    public class StarsPanel : MonoBehaviour
    {
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private Sprite inactiveSprite;
        
        [SerializeField] private List<Image> stars;

        public void ActivateStarsPanel()
        {
            gameObject.SetActive(true);
        }
        public void SetActiveStars(int countStar)
        {
            for (var i = 0; i < stars.Count; i++)
            {
                stars[i].sprite = i < countStar ? activeSprite : inactiveSprite;
            }
        }
    }
}