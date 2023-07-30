using System;
using Tools.MaxCore.Scripts.Project.Audio;
using Tools.MaxCore.Scripts.Project.DI;
using UnityEngine;

namespace Tools.MaxCore.Scripts.ComponentHelp
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class ButtonUI : MonoBehaviour
    {
        private ProjectAudioPlayer ProjectAudioPlayer => ProjectContext.Instance.GetDependence<ProjectAudioPlayer>();
        public event Action OnClick;

        public void OnMouseUp()
        {
            OnClick?.Invoke();
            
            if (ProjectAudioPlayer != null) 
                ProjectAudioPlayer.PlayAudioSfx(ProjectAudioType.Click);
        }

        public void TurnOff() => 
            enabled = false;
    
        public void TurnOn() => 
            enabled = false;
    }
}