using UnityEngine;
using UnityEngine.Tilemaps;

namespace Level.Managment
{
    public class LevelBuilder : MonoBehaviour
    {
        public Tilemap Tilemap;
        public GameObject Character;

        private void Start()
        {
            //Character.transform.position = Tilemap.GetCellCenterWorld(Vector3Int.RoundToInt( Character.transform.position));
        }
    }
}