using System;
using UnityEngine;

namespace Game.Scripts.Runtime.Services.SateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        public LevelState LevelState { get; private set; }

        public event Action<LevelState> OnChangeState;
        
        public void SetLevelState(LevelState selectState)
        {
            LevelState = selectState;
            
            OnChangeState?.Invoke(LevelState);
            Debug.Log(selectState);
        }
    }
}