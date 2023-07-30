using Tools.MaxCore.Scripts.Project.DI;
using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.Audio.AudioCore;
using Tools.MaxCore.Scripts.Services.DataHubService;
using Tools.MaxCore.Scripts.Services.DataHubService.Data;
using UnityEngine;
using AudioType = Tools.MaxCore.Scripts.Services.Audio.AudioCore.AudioType;

namespace Tools.MaxCore.Example.View.Settings
{
    public class SettingService : MonoBehaviour, IProjectInitializable
    {
        public SettingsData SettingsData { get; private set; }

        [Inject] private DataHub dataHub;
        [Inject] private AudioService audioService;

        public void Initialize() => 
            SettingsData = dataHub.LoadData<SettingsData>(DataType.Settings);

        public void TurnSound(bool isOn)
        {
            var value = isOn ? 0 : -80;
            audioService.SetVolume(AudioType.Music, value);
            audioService.SetVolume(AudioType.Sfx, value);
            
            SettingsData.IsSound = isOn;
        }
        public void TurnMusic(bool isOn)
        {
            var value = isOn ? -20 : -80;
            audioService.SetVolume(AudioType.Background, value);
            
            SettingsData.IsMusic = isOn;
        }
        public void ChangeVibro(bool isOn) => 
            SettingsData.IsVibro = isOn;

        public void ChangeSound(float value)
        {
            var intValue = Mathf.Lerp(-80, 0, value);
            
            audioService.SetVolume(AudioType.Music, intValue);
            audioService.SetVolume(AudioType.Sfx, intValue);
            SettingsData.SoundVolumeCount = intValue;
        }

        public void ChangeMusic(float value)
        {
            var intValue = Mathf.Lerp(-80, -20, value);
          
            audioService.SetVolume(AudioType.Background, intValue);
            SettingsData.MusicVolumeCount = intValue;
            
        }
        
        public float GetMusicValue => 
            (SettingsData.MusicVolumeCount - (-80)) / (-20 - (-80));
        public float GetSoundValue => 
            (SettingsData.SoundVolumeCount - (-80)) / (0 - (-80));

        public void SaveData() =>
            dataHub.SaveData(DataType.Settings, SettingsData);
    }
}