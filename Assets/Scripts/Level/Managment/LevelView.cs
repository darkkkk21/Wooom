using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Level.Managment
{
    public class LevelView : MonoBehaviour
    {
        public EnergyHandler EnergyHandler;
        
        public Slider SliderProgress;
        public Text CountLevelText;

        private void Awake()
        {
            EnergyHandler.OnChangeLevel += SetLevel;
            EnergyHandler.OnChangeProgress += SetSlider;
        }

        public void SetLevel(int value)
        {
            CountLevelText.text = (value+1).ToString();
        }

        public void SetSlider(float value)
        {
            if (value == 0)
            {
                SliderProgress.value = 0;
                return;
            }
                
            SliderProgress.DOValue(value, .5f).Play();
        }
    }
}