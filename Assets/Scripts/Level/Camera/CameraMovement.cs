using UnityEngine;

namespace Level.Managment
{
    public class CameraMovement : MonoBehaviour
    {
        public Transform playerTransform;
        public float edgeDistance = 0.1f; // Расстояние от края экрана, при достижении которого камера начнет двигаться
        public float movementSpeed = 5f; // Скорость движения камеры
        public float smoothing = 0.5f;
        
        private float screenWidth;
        private float screenHeight;
        private void Start()
        {
            screenWidth = Screen.width;
            screenHeight = Screen.height;
        }

        private void Update()
        {
            Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(playerTransform.position);
            float horizontalMovement = 0f;
            float verticalMovement = 0f;

            // Проверяем, находится ли игрок в определенном расстоянии от края экрана
            if (playerScreenPosition.x < edgeDistance*2 * screenWidth)
            {
                horizontalMovement = -1f;
            }
            else if (playerScreenPosition.x > (1f - edgeDistance*2) * screenWidth)
            {
                horizontalMovement = 1f;
            }

            if (playerScreenPosition.y < edgeDistance * screenHeight)
            {
                verticalMovement = -1f;
            }
            else if (playerScreenPosition.y > (1f - edgeDistance) * screenHeight)
            {
                verticalMovement = 1f;
            }

            Vector3 targetPosition = transform.position + new Vector3(horizontalMovement, verticalMovement, 0f) * movementSpeed;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
}