using System;
using Tools.MaxCore.Scripts.Services.UIViewService.ViewAnimator;
using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.UIViewService
{
    public abstract class BaseView : MonoBehaviour
    {
        public UIViewType UIViewType { get; private set; }
        
        private BaseViewAnimator animator;
        public event Action OnCloseView;
        public event Action OnOpenView;
        

        private void Start()
        {
            Initialize();
            Subscribe();
            NotifyAnimator();
            Open();

            OnOpenView?.Invoke();
        }

        private void OnDestroy()
        {
            ResetView();
        }

        protected abstract void Initialize();
        protected abstract void Subscribe();
        protected abstract void Open();
        protected abstract void Unsubscribe();

        protected void ClosePanel()
        {
            CheckDestroy();
        }
        public void DestroyView()
        {
            Destroy(gameObject);
        }

        public void SetView(UIViewType type)
        {
            UIViewType = type;
        }
        
        private void UnsubscribeAllEvent()
        {
            OnCloseView = null;
            OnOpenView = null;
        }

        private void ResetView()
        {
            Unsubscribe();
            OnCloseView?.Invoke();
            UnsubscribeAllEvent();
        }

        private void CheckDestroy()
        {
            if (animator == null)
            {
                DestroyView();
            }
            else
            {
                animator.Close();
            }
        }
        private void NotifyAnimator()
        {
            animator = GetComponent<BaseViewAnimator>();
            
            if (animator != null)
            {
                animator.Open();
            }
        }
    }
}