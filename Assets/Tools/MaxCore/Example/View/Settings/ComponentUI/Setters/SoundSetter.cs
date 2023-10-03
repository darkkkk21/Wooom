using System;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.MaxCore.Example.View.Settings.ComponentUI
{
    public abstract class SoundSetter : MonoBehaviour
    {
        protected const int MinValueMixer = -80;
        protected const int MaxSoundValueMixer = 0;
        protected const int MaxMusicValueMixer = -20;

        protected float MusicValue { get; private set; }
        protected float SoundValue { get; private set; }
        
        public event Action<float> OnChangeMusic;
        public event Action<float> OnChangeSound;


        public abstract void Initialize();
        
        protected void NotifyChangeSound(float value)
        {
            OnChangeSound?.Invoke(value);
        }

        protected void NotifyChangeMusic(float value)
        {
            OnChangeMusic?.Invoke(value);
        }

        public void SetValues(float musicValue, float soundValue)
        {
            MusicValue = musicValue;
            SoundValue = soundValue;
        }
    }
}