using System;
using Tools.MaxCore.Scripts.Services.DataHubService;
using Tools.MaxCore.Tools.SerializableComponent;

namespace Tools.MaxCore.Scripts.Services.ResourceVaultService
{
    [Serializable]
    public class ResourceData : DataPayload
    {
        public SerializableDictionary<ResourceType, int> MapInt;
        public SerializableDictionary<ResourceType, float> MapFloat;
    }
}