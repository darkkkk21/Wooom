using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.ResourceVaultService
{
    public class ResourceVault : MonoBehaviour
    {
        private Dictionary<ResourceType, Resource<int>> resourcesMapInt;
        private Dictionary<ResourceType, Resource<float>> resourcesMapFloat;

        public event Action<ResourceType, int> OnResourceChanged;
        public event Action<ResourceType, float> OnFloatResourceChanged;

        public void Initialize(Resource<int>[] resources)
        {
            resourcesMapInt = resources.ToDictionary(r => r.Type);

            SubscribeAllResourcesInt();
        }
        public void Initialize(Resource<float>[] resources)
        {
            resourcesMapFloat = resources.ToDictionary(r => r.Type);

            SubscribeAllResourcesFloat();
        }

        public void AddResource(ResourceType type, int value)
        {
            var resource = resourcesMapInt[type];
            resource.Amount += value;
        }

        public void SpendResource(ResourceType type, int value)
        {
            var resource = resourcesMapInt[type];
            resource.Amount -= value;
        }

        public bool IsEnoughResource(ResourceType type, int value)
        {
            return resourcesMapInt[type].Amount >= value;
        }

        public int GetResourceAmount(ResourceType type)
        {
            return resourcesMapInt[type].Amount;
        }

        public Dictionary<ResourceType, int> GetResourcesAmountMap()
        {
            var resourcesAmountMap = new Dictionary<ResourceType, int>();

            foreach (var (resourceType, resource) in resourcesMapInt)
            {
                resourcesAmountMap.Add(resourceType, resource.Amount);
            }

            return resourcesAmountMap;
        }
        public void AddResource(ResourceType type, float value)
        {
            var resource = resourcesMapFloat[type];
            resource.Amount += value;
        }

        public void SpendResource(ResourceType type, float value)
        {
            var resource = resourcesMapFloat[type];
            resource.Amount -= value;
        }

        public bool IsEnoughResource(ResourceType type, float value)
        {
            return resourcesMapFloat[type].Amount >= value;
        }

        public float GetFloatResourceAmount(ResourceType type)
        {
            return resourcesMapFloat[type].Amount;
        }

        public Dictionary<ResourceType, float> GetFloatResourcesAmountMap()
        {
            var resourcesAmountMap = new Dictionary<ResourceType, float>();

            foreach (var (resourceType, resource) in resourcesMapFloat)
            {
                resourcesAmountMap.Add(resourceType, resource.Amount);
            }

            return resourcesAmountMap;
        }

        private void SubscribeAllResourcesInt()
        {
            foreach (var resource in resourcesMapInt.Values)
            {
                resource.OnChanged += delegate(int newValue) { OnResourceChanged?.Invoke(resource.Type, newValue); };
            }
        }
        private void SubscribeAllResourcesFloat()
        {
            foreach (var resource in resourcesMapFloat.Values)
            {
                resource.OnChanged += delegate(float newValue) { OnFloatResourceChanged?.Invoke(resource.Type, newValue); };
            }
        }
    }
}