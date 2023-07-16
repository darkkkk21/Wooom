using DG.Tweening;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Level
{
    public class CharacterMovement : MonoBehaviour
    {
        public float swipeThreshold = 50f;
        public Tilemap Tilemap;

        private Vector3Int currentCell;
        private Vector3 swipeStartPosition;
        private bool isMove;

        private void Start()
        {
            currentCell = Tilemap.WorldToCell(transform.position);
        }

        private void Update()
        {
            if (isMove)
                return;
            
            HandleTouch();
            HandleKeyboardMovement();
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
                                    TryMoveCharacter(Vector3Int.right);
                                }
                                else
                                {
                                    TryMoveCharacter(Vector3Int.left);
                                }
                            }
                            else
                            {
                                if (swipeDirection.y > 0)
                                {
                                    TryMoveCharacter(Vector3Int.up);
                                }
                                else
                                {
                                    TryMoveCharacter(Vector3Int.down);
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
                TryMoveCharacter(Vector3Int.up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                TryMoveCharacter(Vector3Int.down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                TryMoveCharacter(Vector3Int.left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                TryMoveCharacter(Vector3Int.right);
            }
        }

        private void TryMoveCharacter(Vector3Int direction)
        {
            Vector3Int targetCell = currentCell + direction;

            Vector3 targetPosition = Tilemap.GetCellCenterWorld(targetCell);
            Collider2D overlapCollider = Physics2D.OverlapPoint(new Vector2(targetPosition.x, targetPosition.y));

            if (overlapCollider == null)
            {
                Move(targetPosition);
                currentCell = targetCell;
            }
        }

        private void Move(Vector3 position)
        {
            isMove = true;
            transform.DOMove(position, 0.4f)
                .OnComplete(() => isMove = false)
                .Play();
        }
    }
}