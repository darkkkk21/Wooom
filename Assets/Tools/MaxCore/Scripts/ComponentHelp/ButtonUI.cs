using System;
using Tools.MaxCore.Scripts.Project.Audio;
using Tools.MaxCore.Scripts.Project.DI;
using UnityEngine;

namespace Tools.MaxCore.Scripts.ComponentHelp
{
    public class ButtonUI : MonoBehaviour
    {
        [SerializeField] private Collider2D collider2D;
        
        private ProjectAudioPlayer ProjectAudioPlayer => ProjectContext.Instance.GetDependence<ProjectAudioPlayer>();
        public event Action OnClick;

        public void OnMouseUp()
        {
            OnClick?.Invoke();
            
            if (ProjectAudioPlayer != null) 
                ProjectAudioPlayer.PlayAudioSfx(ProjectAudioType.Click);
        }

        public void Diactivate()
        {
            collider2D.enabled = false;
        }

        public void Activate()
        {
            collider2D.enabled = true;
        }
    }
}