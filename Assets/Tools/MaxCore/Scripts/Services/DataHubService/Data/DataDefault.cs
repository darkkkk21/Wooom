using System.Collections.Generic;
using Game.Scripts.Runtime.Feature.Player;
using Game.Scripts.Runtime.Feature.UIViews.LevelSelect;
using Tools.MaxCore.Example.View.Settings;
using Tools.MaxCore.Scripts.Services.ResourceVaultService;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.DataHubService.Data
{
    [CreateAssetMenu(menuName = "Core/Services/DataHub", fileName = "DataDefault")]
    public class DataDefault : ScriptableObject
    {
        [SerializeField]private ResourceData _resource;
        public SettingsData Settings;
        public PlayerProgressData Progress;
        public SelectLevelData SelectLevel;

        public Dictionary<DataType, DataPayload> DatesMap()
        {
            var datesMap = new Dictionary<DataType, DataPayload>();

            datesMap.Add(DataType.Resource, _resource);
            datesMap.Add(DataType.Settings, Settings);
            datesMap.Add(DataType.Progress, Progress);
            datesMap.Add(DataType.SelectLevel, SelectLevel);

            return datesMap;
        }
    }
}