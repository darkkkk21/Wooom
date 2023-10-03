using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.SceneLoaderService;
using Tools.MaxCore.Scripts.Services.UIViewService;
using Tools.MaxCore.Tools.SerializableComponent;
using Tools.MaxCore.Tools.SlotMachine.Scripts.Data;
using Tools.MaxCore.Tools.SlotMachine.Scripts.SlotEngine;
using UnityEngine;

namespace Game.Scripts.Runtime.Feature.UIViews.Slot
{
    public class SlotMachineController : MonoBehaviour
    {
        [SerializeField] private SerializableDictionary<PanelInfoTextMap, string> _infoTextMap;

        [SerializeField] private SlotHandler _slotHandler;
        [SerializeField] private SlotMachineView _view;

        [Inject] private SceneNavigation sceneNavigation;
        [Inject] private UIViewService uiViewService;

        private int attempts;
        private bool IsEnoughAttempts => attempts > 0;
        public bool IsWin { get; private set; }

        private void Start()
        {
            attempts = 23;

            _slotHandler.CreateSlotMachine();

            _view.SetSpinButton(SpinSlot);

            _slotHandler.OnStartSpin += ActionsOnStart;
            _slotHandler.OnFinishSpin += CheckFinish;
            _slotHandler.OnGetWinSymbol += GetWinBonus;
        }

        private void OnDestroy()
        {
            _slotHandler.OnStartSpin -= ActionsOnStart;
            _slotHandler.OnFinishSpin -= CheckFinish;
            _slotHandler.OnGetWinSymbol -= GetWinBonus;
        }

        private void SpinSlot()
        {
            _slotHandler.NotifyStartSpin();
        }

        private void ActionsOnStart()
        {
            _view.DeactivateSpinButton();
            _view.ChangeCountText(--attempts);
        }

        private void CheckFinish()
        {
            if (IsWin)
            {
                return;
            }

            if (!IsEnoughAttempts)
            {
                _view.SetLoseView(_infoTextMap[PanelInfoTextMap.Lose]);
            }
            
            _view.ActivateSpinButton();
        }

        private void GetWinBonus(SlotSymbolPayType slotSymbolPayType)
        {
            _view.SetWinView(() =>
            {
                uiViewService.RemoveAllViews();
            });

            IsWin = true;
        }
    }

    public enum PanelInfoTextMap
    {
        Lose,
        Win
    }
}