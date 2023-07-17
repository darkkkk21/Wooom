using System;
using UnityEngine;

namespace Level
{
    public class CharacterInput : MonoBehaviour
    {
        public float swipeThreshold = 50f;
        private Vector3 swipeStartPosition;

        public event Action<Vector3Int> OnGetMove;

        private bool isLock;
        private void Update()
        {
            if (isLock)
                return;
            
            HandleTouch();
            HandleKeyboardMovement();
        }

        public void Lock()
        {
            isLock = true;
        }
        
        public void Unlock()
        {
            isLock = false;
        }
        
        private void HandleTouch()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        swipeStartPosition = touch.position;
                        break;

                    case TouchPhase.Ended:
                        Vector3 swipeEndPosition = touch.position;
                        Vector3 swipeDirection = swipeEndPosition - swipeStartPosition;

                        if (swipeDirection.magnitude >= swipeThreshold)
                        {
                            swipeDirection.Normalize();

                            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                            {
                                if (swipeDirection.x > 0)
                                {
                                    OnGetMove?.Invoke(Vector3Int.right);
                                }
                                else
                                {
                                    OnGetMove?.Invoke(Vector3Int.left);
                                }
                            }
                            else
                            {
                                if (swipeDirection.y > 0)
                                {
                                    OnGetMove?.Invoke(Vector3Int.up);
                                }
                                else
                                {
                                    OnGetMove?.Invoke(Vector3Int.down);
                                }
                            }
                        }

                        break;
                }
            }
        }

        private void HandleKeyboardMovement()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                OnGetMove?.Invoke(Vector3Int.up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                OnGetMove?.Invoke(Vector3Int.down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                OnGetMove?.Invoke(Vector3Int.left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                OnGetMove?.Invoke(Vector3Int.right);
            }
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}