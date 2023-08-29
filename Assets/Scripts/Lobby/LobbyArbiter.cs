using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.SceneLoaderService;
using Tools.MaxCore.Scripts.Services.UIViewService;
using UnityEngine;

namespace Lobby
{
    public class LobbyArbiter : MonoBehaviour
    {
        [Inject] private SceneNavigation sceneNavigation;
        [Inject] private UIViewService uiViewService;

        public void CreateSettingsView()
        {
            uiViewService.Instantiate(UIViewType.Settings);
        }

        public void RunLevel()
        {
            sceneNavigation.LoadLevel();
        }
    }
}