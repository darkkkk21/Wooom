using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Runtime.Feature.UIViews.Shop.Components
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _getButton;
        [SerializeField] private Text _countItemText;

        public void SetImage(Sprite sprite)
        {
            _itemImage.sprite = sprite;
        }

        public void SetBuyButton(Action callback)
        {
            _buyButton.onClick.AddListener(() => callback?.Invoke());
        }
        
        public void SetGetButton(Action callback)
        {
            _getButton.onClick.AddListener(() => callback?.Invoke());
        }

        public void SetCountText(string value)
        {
            _countItemText.text = value;
        }

        public void SetItemPurchased()
        {
            _getButton.gameObject.SetActive(true);
        }

        public void SetItemCanBuy()
        {
            _buyButton.gameObject.SetActive(true);
        }

        public void SetItemNotCanBuy()
        {
            _buyButton.gameObject.SetActive(true);
            _buyButton.interactable = false;
        }

        public void SetItemSelected()
        {
            _buyButton.gameObject.SetActive(false);
            _getButton.gameObject.SetActive(false);
        }

        public void ResetItem()
        {
            _buyButton.onClick.RemoveAllListeners();
            _getButton.onClick.RemoveAllListeners();
        }
    }
}