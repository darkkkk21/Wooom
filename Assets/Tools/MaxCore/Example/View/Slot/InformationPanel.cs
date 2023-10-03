using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Runtime.Feature.UIViews.Slot
{
    public class InformationPanel : MonoBehaviour
    {
        [SerializeField] private Text _panelText;
        [SerializeField] private Text _countAttempts;
        [SerializeField] private Text _countAttemptsText;
        [SerializeField] private Text _congratsText;

        public void SetText(string value)
        {
            _panelText.text = value;
        }

        public void SetWin()
        {
            _congratsText.gameObject.SetActive(true);
            
            _panelText.gameObject.SetActive(false);
            _countAttempts.gameObject.SetActive(false);
            _countAttemptsText.gameObject.SetActive(false);
        }

        public void SetCountText(string value)
        {
            _countAttempts.text = $" {value}";
        }
    }
}