using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Tools.MaxCore.Scripts.Project.DI;
using Tools.MaxCore.Scripts.Services.UIViewService.Data;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.UIViewService
{
    public class UIViewService : MonoBehaviour, IProjectInitializable
    {
        [SerializeField] private UIViewData ViewData;
        
        private UIViewFactory factory;

        private List<BaseView> Views { get; set; }

        public void Initialize()
        {
            factory = new UIViewFactory(ViewData);
            Views = new List<BaseView>();
        }

        public BaseView Instantiate(UIViewType type)
        {
            var instance = factory.InstantiatePrefab(type, transform);
            instance.SetView(type);
            instance.OnCloseView += () => RemoveView(instance);
            
            Views.Add(instance);

            return instance;
        }

        public void InstantiateAsync(UIViewType type , float delay = 0.15f)
        {
            DOVirtual.DelayedCall(delay, () =>
            {
                Instantiate(type);
            }).Play();
        }

        public void RemoveAllViews()
        {
            foreach (var baseView in Views)
            {
                baseView.DestroyView();
            }
        }

        public void DestroyView(BaseView view)
        {
            if (view == null)
            {
                return;
            }
            view.DestroyView();
            RemoveView(view);
        }
        
        public void RemoveView(BaseView view)
        {
            if (view == null)
            {
                return;
            }
            
           
            Views.Remove(view);
        }

        public BaseView GetView(UIViewType view)
        {
           var baseView = Views.FirstOrDefault(v => v.UIViewType == view);
           return baseView != null ? baseView : null;
        }
    }
}