using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.UIViewService;
using UnityEngine;
using UnityEngine.UI;

namespace Tools.MaxCore.Example.View.Settings
{
    public class SettingWithToggleView : BaseView
    {
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _soundToggle;
        
        [SerializeField] private Button _closeButton;

        [Inject] private SettingService settingService;
        [Inject] private UIViewService uiViewService;

        protected override void Initialize()
        {
            
        }

        protected override void Subscribe()
        {
            if (_soundToggle != null)
            {
                _soundToggle.isOn = settingService.SettingsData.IsSound;
                _soundToggle.onValueChanged.AddListener(ChangeSound);
                _soundToggle.onValueChanged.AddListener(ChangeMusic);
            }

            if (_musicToggle != null)
            {
                _musicToggle.isOn = settingService.SettingsData.IsMusic;
                _musicToggle.onValueChanged.AddListener(ChangeMusic);
            }

            if (_closeButton != null)
            {
                _closeButton.onClick.AddListener(ClosePanel);
            }
        }

        protected override void Open()
        {
        }

        protected override void Unsubscribe()
        {
            _soundToggle?.onValueChanged.RemoveAllListeners();
            _closeButton?.onClick.RemoveAllListeners();
            settingService.SaveData();
        }
        
        private void ChangeSound(bool isActive)
        {
            settingService.TurnSound(isActive);
        }
        private void ChangeMusic(bool isActive)
        {
            settingService.TurnMusic(isActive);
        }
    }
}