using System;
using UnityEngine;

namespace Lobby.LevelSelect
{
    public class FieldPoint : MonoBehaviour
    {
        public SideType CurrentSideType;
        public bool IsActive { get; private set; }

        public void Activate(bool value)
        {
            gameObject.SetActive(value);
            IsActive = value;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}
