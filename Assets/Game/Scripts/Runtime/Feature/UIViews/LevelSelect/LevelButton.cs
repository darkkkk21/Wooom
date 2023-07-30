using Tools.MaxCore.Tools.Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Scripts.Runtime.Feature.UIViews.LevelSelect
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private GameObject closedState;
        [SerializeField] private GameObject availableState;
        [SerializeField] private GameObject activeState;

        [SerializeField] StarsPanel starsPanel;

        private Button button;
        [SerializeField] private Text countLevelText;

        public void Initialize()
        {
            button = GetComponent<Button>();
            closedState.SetActive(false);
            availableState.SetActive(false);
            activeState.SetActive(false);
            starsPanel.gameObject.SetActive(false);
        }

        public void SetCountLevelTextForClose(int value)
        {
            countLevelText.SetAlpha(0.7f);
            SetCountLevelText(value);
        }
        public void SetCountLevelText(int value)
        {
            countLevelText.text = (value + 1).ToString();
        }

        public void SetSelectButton(UnityAction call)
        {
            button.onClick.AddListener(call);
        }

        public void SetClose()
        {
            closedState.SetActive(true);
            button.interactable = false;
        }

        public void SetAvailable()
        {
            availableState.SetActive(true);
            button.interactable = true;
        }

        public void SetActive(int countStar)
        {
            activeState.SetActive(true);
            button.interactable = true;
            
            starsPanel.ActivateStarsPanel();
            starsPanel.SetActiveStars(countStar);
        }

        public void ResetButton()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}