using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Managment
{
    public class EnergyHandler : MonoBehaviour
    {
        public List<int> CountEnergyOnLevels;
        
        public int CurrentPlayerLevel;
        public int CurrentEnergy;

        public event Action<float> OnChangeProgress; 
        public event Action<int> OnChangeLevel;

        private void Start()
        {
            CurrentEnergy = 2;
            NotifyChangeSlider();
        }

        public void AddEnergy(int energyLevel)
        {
            CurrentEnergy += energyLevel;
            CheckNextLevel();
            
            NotifyChangeSlider();
        }
        public void Spend(int energyLevel)
        {
            CurrentEnergy -= energyLevel * (CurrentPlayerLevel + 1);
            CheckNextLevel();
            
            NotifyChangeSlider();
        }

        private void CheckNextLevel()
        {
            if (CurrentEnergy <= 0)
            {
                CurrentPlayerLevel--;
                
                if (CurrentPlayerLevel < 0)
                {
                    Debug.Log($"You lose");
                    return;
                }
                    
                OnChangeLevel?.Invoke(CurrentPlayerLevel);
                CurrentEnergy = CountEnergyOnLevels[CurrentPlayerLevel];
                return;
            }
            
            if (CurrentEnergy > CountEnergyOnLevels[CurrentPlayerLevel])
            {
                OnChangeLevel?.Invoke(++CurrentPlayerLevel);
                CurrentEnergy = 0;
            }
        }
        
        private void NotifyChangeSlider()
        {
            float progress = Mathf.InverseLerp(0f, CountEnergyOnLevels[CurrentPlayerLevel], CurrentEnergy);
            OnChangeProgress?.Invoke(progress);
        }
    }
}