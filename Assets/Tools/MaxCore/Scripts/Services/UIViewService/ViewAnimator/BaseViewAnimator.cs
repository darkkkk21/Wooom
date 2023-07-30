using UnityEngine;

namespace Tools.MaxCore.Scripts.Services.UIViewService.ViewAnimator
{
    public abstract class BaseViewAnimator : MonoBehaviour
    {
        protected BaseView BaseView => GetComponent<BaseView>();
        public abstract void Open();
        public abstract void Close();
       
    }
}