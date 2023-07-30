using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.UIViewService;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.MaxCore.Example.View.Settings
{
    public class SettingWithSliderView : BaseView
    {
        [SerializeField] private Slider MusicSlider;
        [SerializeField] private Slider SoundSlider;
        
        [SerializeField] private Button CloseButton;
        
         [Inject] private SettingService settingService ;
         [Inject] private UIViewService uiViewService;

        protected override void Subscribe()
        {
            MusicSlider.onValueChanged.AddListener(settingService.ChangeMusic);
            SoundSlider.onValueChanged.AddListener(settingService.ChangeSound);
            
            CloseButton.onClick.AddListener(ClosePanel);
        }

        protected override void Initialize()
        {
            MusicSlider.value = settingService.GetMusicValue;
            SoundSlider.value = settingService.GetSoundValue;
        }

        protected override void Open()
        {
        }

        protected override void Unsubscribe()
        {
            MusicSlider.onValueChanged.RemoveAllListeners();
            SoundSlider.onValueChanged.RemoveAllListeners();
            
            CloseButton.onClick.RemoveAllListeners();
            
            settingService.SaveData();
        }
    }
}