using System;
using Tools.MaxCore.Scripts.Services.DataHubService;

namespace Tools.MaxCore.Example.View.Settings
{
    [Serializable]
    public class SettingsData : DataPayload
    {
        public float SoundVolumeCount;
        public float MusicVolumeCount;
    }
}