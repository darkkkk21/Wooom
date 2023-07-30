using System;
using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Runtime.Feature.Player;
using Tools.MaxCore.Scripts.Project.Audio;
using Tools.MaxCore.Scripts.Project.DI;
using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.DataHubService;
using Tools.MaxCore.Scripts.Services.DataHubService.Data;
using Tools.MaxCore.Scripts.Services.ResourceVaultService;
using Tools.MaxCore.Scripts.Services.UIViewService;
using UnityEngine;

namespace Game.Scripts.Runtime.Feature.UIViews.Shop
{
    public class ShopController : MonoBehaviour, IProjectInitializable
    {
        public ShopItemInfoData SkinInfoData;

        [Inject] private DataHub dataHub;
        [Inject] private ProjectAudioPlayer projectAudioPlayer;
        [Inject] private UIViewService uiViewService;
        [Inject] private ResourceVault resourceVault;

        private PlayerProgressData progressData;
        public Dictionary<int, ItemInfo> CurrentItemInfo { get; private set; }
        public bool IsEnoughCoins => resourceVault.IsEnoughResource(ResourceType.Coin, 200);
        
        public event Action OnChangePlayerPanel;
        public event Action OnChangeBonusPanel;

        public void Initialize()
        {
            progressData = dataHub.LoadData<PlayerProgressData>(DataType.Progress);
        }

        public void PrepareItemInfoMap()
        {
            CurrentItemInfo = new Dictionary<int, ItemInfo>();

            foreach (var skinInfo in SkinInfoData.PathMap)
            {
                CurrentItemInfo.Add(skinInfo.Key, new ItemInfo()
                {
                    Skin = skinInfo.Value.Skin,
                    Count = skinInfo.Value.Count,
                    ID = skinInfo.Key
                });
            }

            foreach (var skinID in progressData.AvailableSkins)
                CurrentItemInfo[skinID].IsPurchased = true;
            
            foreach (var skinInfo in CurrentItemInfo
                         .Where(i => !i.Value.IsPurchased && resourceVault.IsEnoughResource(ResourceType.Coin, i.Value.Count)))
            {
                skinInfo.Value.IsCanPurchased = true;
            }

            CurrentItemInfo[progressData.CurrentIDItem].IsSelected = true;

        }

        public void PurchaseItem(int itemID)
        {
            progressData.AvailableSkins.Add(itemID);
            resourceVault.SpendResource(ResourceType.Coin, CurrentItemInfo[itemID].Count);
            SetCurrentItem(itemID);
        }

        public void SetCurrentItem(int itemID)
        {
            progressData.CurrentIDItem = itemID;
            PrepareItemInfoMap();
            SaveData();
            
            OnChangePlayerPanel?.Invoke();
        }

        public void BuyCrazyGameBonus()
        {
            if (IsEnoughCoins)
            {
                resourceVault.SpendResource(ResourceType.Coin,200);
                resourceVault.AddResource(ResourceType.CrazyBonus, 1);
                
                OnChangeBonusPanel?.Invoke();
            }
        }
        public void BuyX2CoinBonus()
        {
            if (IsEnoughCoins)
            {
                resourceVault.SpendResource(ResourceType.Coin,200);
                resourceVault.AddResource(ResourceType.X2Bonus, 1);
                
                OnChangeBonusPanel?.Invoke();
            }
        }

        public void OpenPuzzleView()
        {
            uiViewService.Instantiate(UIViewType.Puzzle);
        }

        public void SaveData()
        {
            dataHub.SaveData(DataType.Progress, progressData);   
        }
    }
}