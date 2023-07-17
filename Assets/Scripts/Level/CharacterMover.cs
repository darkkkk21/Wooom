using DG.Tweening;
using Level.Managment;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Level
{
    public class CharacterMover : MonoBehaviour
    {
        public EnergyHandler EnergyHandler;
        public CharacterInput CharacterInput;
        public Tilemap Tilemap;
        private Vector3Int currentCell;
        
        private void Start()
        {
            currentCell = Tilemap.WorldToCell(transform.position);
            CharacterInput.OnGetMove += TryMoveCharacter;
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
                EnergyHandler.Spend(1);
            }

            if (overlapCollider != null && overlapCollider.GetComponent<Energy>())
            {
                var energy = overlapCollider.GetComponent<Energy>();
                EnergyHandler.AddEnergy(energy.LevelEnergy);
                Destroy(energy.gameObject);

                Move(targetPosition);
                currentCell = targetCell;
            }
        }

        private void Move(Vector3 position)
        {
            CharacterInput.Lock();
            
            transform.DOMove(position, 0.4f)
                .OnComplete(() => CharacterInput.Unlock())
                .Play();
        }
    }
}