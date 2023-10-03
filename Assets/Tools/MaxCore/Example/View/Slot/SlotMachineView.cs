using System;
using Tools.MaxCore.Scripts.Services.UIViewService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.Runtime.Feature.UIViews.Slot
{
    public class SlotMachineView : BaseView
    {
        [SerializeField] private SpinMachineButton _spinButton;
        [SerializeField] private GameObject _slotMachine;

        [SerializeField] private InformationPanel _informationPanel;

        protected override void Initialize()
        {
        }

        protected override void Subscribe()
        {
        }

        protected override void Open()
        {
        }

        protected override void Unsubscribe()
        {
            _spinButton.RemoveAllListeners();
        }

        public void SetSpinButton(UnityAction callback)
        {
            _spinButton.SetSpin(callback);
        }

        public void SetWinView(UnityAction callback)
        {
            _informationPanel.SetWin();
            _spinButton.SetPlay(callback);
        }

        public void SetLoseView(string value)
        {
            _informationPanel.SetText(value);
            _spinButton.SetBack(()=> DestroyView());
        }

        public void ActivateSpinButton()
        {
            _spinButton.Interactable = true;
        }

        public void DeactivateSpinButton()
        {
            _spinButton.Interactable = false;
        }

        public void ChangeCountText(int value)
        {
            _informationPanel.SetCountText(value.ToString());
        }

        public void HideSlotMachine()
        {
            _slotMachine.SetActive(false);
        }
    }
}