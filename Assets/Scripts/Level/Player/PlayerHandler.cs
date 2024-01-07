using System;
using UnityEngine;

namespace Level.Player
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;
        [SerializeField] private PlayerScaler _scalerX;
        [SerializeField] private PlayerMover _mover;
        
        [SerializeField] private Transform _relative;

        private void Start()
        {
            _animator.RunIdle();
        }

        public void Update()
        {
            //var distance = Vector2.Distance(transform.position, _relative.position);

            if (_mover.DirectionType is Direction.Down or Direction.Up)
            {
                _scalerX.SetScaleForY(transform.position.y - _relative.position.y);
            }
            if (_mover.DirectionType is Direction.Left or Direction.Right)
            {
                _scalerX.SetScaleForX(transform.position.x - _relative.position.x);
            }
                
           
           
            //_scalerX.SetScale(distance);
        }
    }
}