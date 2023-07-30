using System;
using Tools.MaxCore.Scripts.Services.DataHubService;

namespace Tools.MaxCore.Example.View.Settings
{
    [Serializable]
    public class SettingsData : DataPayload
    {
        public bool IsSound;
        public bool IsMusic;
        public bool IsVibro;

        public bool IsSliderActive;
        public float SoundVolumeCount;
        public float MusicVolumeCount;
    }
}