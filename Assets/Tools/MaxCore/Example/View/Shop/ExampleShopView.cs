using System.Collections.Generic;
using Game.Scripts.Runtime.Feature.UIViews.Shop.Components;
using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.UIViewService;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Runtime.Feature.UIViews.Shop
{
    public class ExampleShopView : BaseView
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _puzzleButton;
        [SerializeField] List<ShopItem> _shopItems;

        [SerializeField] private Button _crazyGameButton;
        [SerializeField] private Button _x2CoinButton;

        [Inject] private ExampleShopController exampleShopController;

        protected override void Initialize()
        {
            PreparePlayerPanel();
            UpdateBonusPanel();
        }

        protected override void Subscribe()
        {
            _closeButton.onClick.AddListener(ClosePanel);
            _puzzleButton.onClick.AddListener(exampleShopController.OpenPuzzleView);
            _crazyGameButton.onClick.AddListener(exampleShopController.BuyCrazyGameBonus);
            _x2CoinButton.onClick.AddListener(exampleShopController.BuyX2CoinBonus);

            exampleShopController.OnChangePlayerPanel += UpdatePlayerPanel;
            exampleShopController.OnChangeBonusPanel += UpdateBonusPanel;
        }

        protected override void Open()
        {
        }

        protected override void Unsubscribe()
        {
            _closeButton.onClick.RemoveAllListeners();
            _crazyGameButton.onClick.RemoveAllListeners();
            _x2CoinButton.onClick.RemoveAllListeners();
            
            exampleShopController.OnChangePlayerPanel -= UpdatePlayerPanel;
            exampleShopController.OnChangeBonusPanel -= UpdateBonusPanel;
        }

        private void PreparePlayerPanel()
        {
            for (var i = 0; i < _shopItems.Count; i++)
            {
                var itemInfo = exampleShopController.CurrentItemInfo[i];

                _shopItems[i].SetImage(itemInfo.Skin);
                _shopItems[i].SetCountText(itemInfo.Count.ToString());

                PrepareShopItems(itemInfo, i);
            }
        }

        private void PrepareShopItems(ItemInfo itemInfo, int i)
        {
            if (itemInfo.IsSelected)
            {
                _shopItems[i].SetItemSelected();
                return;
            }

            if (itemInfo.IsPurchased)
            {
                _shopItems[i].SetItemPurchased();
                _shopItems[i].SetGetButton(() => exampleShopController.SetCurrentItem(itemInfo.ID));
                return;
            }

            if (itemInfo.IsCanPurchased)
            {
                _shopItems[i].SetItemCanBuy();
                _shopItems[i].SetBuyButton(() => exampleShopController.PurchaseItem(itemInfo.ID));
            }
            else
            {
                _shopItems[i].SetItemNotCanBuy();
            }
        }

        private void UpdatePlayerPanel()
        {
            for (var i = 0; i < _shopItems.Count; i++)
            {
                var itemInfo = exampleShopController.CurrentItemInfo[i];
                _shopItems[i].ResetItem();
                PrepareShopItems(itemInfo, i);
            }
        }

        private void UpdateBonusPanel()
        {
            _crazyGameButton.interactable = exampleShopController.IsEnoughCoins;
            _x2CoinButton.interactable = exampleShopController.IsEnoughCoins;
        }
    }
}