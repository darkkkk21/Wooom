using System.Collections.Generic;
using Game.Scripts.Runtime.Feature.Player;
using Tools.MaxCore.Scripts.Project.DI;
using Tools.MaxCore.Scripts.Services.DataHubService.Data;
using Tools.MaxCore.Scripts.Services.DataHubService.SaveLoadService;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.DataHubService
{
    public class DataHub : MonoBehaviour, IProjectInitializable
    {
        private readonly Dictionary<DataType, DataPayload> AllData = new Dictionary<DataType, DataPayload>();

        public DataDefault DataDefault;
        
        private ISaveLoadService<DataKey> saveLoadService;
        public LevelGameData LevelGameData { get; private set; }
        
        public void Initialize()
        {
            saveLoadService = new PlayerPrefsSaveLoadService();
            LevelGameData = new LevelGameData();

            InitializeDefaultData();
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