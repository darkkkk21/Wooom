using System.Collections.Generic;
using System.Linq;
using Game.Scripts.Runtime.Feature.Player;
using Tools.MaxCore.Scripts.Project.DI;
using Tools.MaxCore.Scripts.Project.DI.ProjectInjector;
using Tools.MaxCore.Scripts.Services.DataHubService.Data;
using Tools.MaxCore.Scripts.Services.DataHubService.SaveLoadService;
using Tools.MaxCore.Scripts.Services.ResourceVaultService;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.DataHubService
{
    public class DataHub : MonoBehaviour, IProjectInitializable
    {
        private readonly Dictionary<DataType, DataPayload> AllData = new Dictionary<DataType, DataPayload>();

        public DataDefault DataDefault;
        
        [Inject] private ResourceVault resourceVault;
        
        private ISaveLoadService<DataKey> saveLoadService;
        private ResourceData resourcesData;
        public LevelGameData LevelGameData { get; private set; }
        
        public void Initialize()
        {
            saveLoadService = new PlayerPrefsSaveLoadService();
            LevelGameData = new LevelGameData();

            InitializeDefaultData();
            InitializeResources();
        }

        private void OnApplicationQuit()
        {
            SaveResources();
        }

        private void InitializeDefaultData()
        {
            if (PlayerPrefs.GetInt("IsFirstRun") == 1)
                return;

            foreach (var data in DataDefault.DatesMap())
            {
                data.Value.InitializeDefault();

                SaveData(data.Key, data.Value);
            }

            PlayerPrefs.SetInt("IsFirstRun", 1);
            PlayerPrefs.Save();
        }

        private void InitializeResources()
        {
            resourcesData = LoadData<ResourceData>(DataType.Resource);
            var resources = resourcesData.MapInt.Select(r => new Resource<int>(r.Key, r.Value)).ToArray();
            var resourcesFloat = resourcesData.MapFloat.Select(r => new Resource<float>(r.Key, r.Value)).ToArray();

            resourceVault.Initialize(resources);
            resourceVault.Initialize(resourcesFloat);
        }

        private void SaveResources()
        {
            var resourcesMap = resourceVault.GetResourcesAmountMap();

            foreach (var resourceType in resourcesMap.Keys)
            {
                resourcesData.MapInt[resourceType] = resourcesMap[resourceType];
            }
            
            var floatResourcesMap = resourceVault.GetFloatResourcesAmountMap();

            foreach (var resourceType in floatResourcesMap.Keys)
            {
                resourcesData.MapFloat[resourceType] = floatResourcesMap[resourceType];
            }
            
            SaveData(DataType.Resource, resourcesData);
        }

        public void SaveData<T>(DataType key, T data) where T : DataPayload
        {
            saveLoadService.Save(new DataKey(key.ToString(), "Data"), data);
            AllData[key] = data;
        }

        public T LoadData<T>(DataType key) where T : DataPayload
        {
            if (AllData.ContainsKey(key))
            {
                return (T)AllData[key];
            }

            var loadedData = saveLoadService.Load<T>(new DataKey(key.ToString(), "Data"));
            AllData[key] = loadedData;
            return loadedData;
        }
    }
}