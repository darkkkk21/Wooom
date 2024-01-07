using System;
using DG.Tweening;
using UnityEngine;

namespace Level.Player
{
    public class PlayerMover : MonoBehaviour
    {
        public float offset;
        public Direction DirectionType;

        private void Start()
        {
            DirectionType = Direction.Down;
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                var pos = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
                transform.DOMove(pos, 0.4f).Play();
                DirectionType = Direction.Up;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                var pos = new Vector3(transform.position.x, transform.position.y - offset, transform.position.z);
                transform.DOMove(pos, 0.4f).Play();
                DirectionType = Direction.Down;
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                var pos = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);
                transform.DOMove(pos, 0.4f).Play();
                DirectionType = Direction.Left;
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                var pos = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
                transform.DOMove(pos, 0.4f).Play();
                DirectionType = Direction.Right;
            }
            
        }
    }
}