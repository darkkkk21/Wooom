using Game.Scripts.Runtime.Feature.UIViews.LevelSelect;
using Game.Scripts.Runtime.Feature.UIViews.Shop;
using Game.Scripts.Runtime.Services.SateMachine;
using Tools.MaxCore.Example.View.Settings;
using Tools.MaxCore.Scripts.ComponentHelp;
using Tools.MaxCore.Scripts.Project.Audio;
using Tools.MaxCore.Scripts.Services.Audio.AudioCore;
using Tools.MaxCore.Scripts.Services.DataHubService;
using Tools.MaxCore.Scripts.Services.ResourceVaultService;
using Tools.MaxCore.Scripts.Services.SceneLoaderService;
using Tools.MaxCore.Scripts.Services.UIViewService;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Project.DI
{
    public class ProjectInstaller : MonoBehaviour
    {
        public ImageFader SceneFader;
        public AudioService AudioService;
        public SettingService SettingService;
        public SceneNavigation SceneNavigation;
        public ProjectAudioPlayer ProjectAudioPlayer;
        public UIViewService UIViewService;
        public DataHub DataHub;
        public ResourceVault ResourceVault;
        public GameStateMachine StateMachine;

        [Header("Controllers in MVC")] 
        public SelectLevelController SelectLevelController;
        public ShopController ShopController;

        private DIContainer container;

        public DIContainer RegisterDependencies()
        {
            container = new DIContainer();
            container.Register(container);

            RegisterServices();
            RegisterControllers();

            return container;
        }

        private void RegisterControllers()
        {
            container.Register(SelectLevelController);
            container.Register(ShopController);
        }

        private void RegisterServices()
        {
            container.Register(SceneFader);
            container.Register(AudioService);
            container.Register(SettingService);
            container.Register(SceneNavigation);
            container.Register(ProjectAudioPlayer);
            container.Register(UIViewService);
            container.Register(ResourceVault);
            container.Register(DataHub);
            container.Register(StateMachine);
        }
    }
}