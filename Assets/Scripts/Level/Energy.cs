using System;
using TMPro;
using UnityEngine;

namespace Level
{
    public class Energy : MonoBehaviour
    {
        public TextMeshPro CountLevelText;
        public int LevelEnergy;

        public void Start()
        {
            CountLevelText.text = LevelEnergy.ToString();
        }
    }
}