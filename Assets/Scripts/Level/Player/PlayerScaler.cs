using UnityEngine;

namespace Level.Player
{
    public class PlayerScaler : MonoBehaviour
    {
        [SerializeField] private Vector3 _scaleDown;
        [SerializeField] private Vector3 _scaleUp;
        [SerializeField] private Vector3 _scaleDefault;

        [SerializeField] private float _scaleKoefficient;
        
        public void SetScaleForX(float intrepolant)
        {
            var scale = Lerp3(_scaleDown, _scaleDefault, _scaleUp, Mathf.Abs(intrepolant));
            transform.localScale = new Vector2(scale.x, scale.y);
        }
        public void SetScaleForY(float intrepolant)
        {
            var scale = Lerp3(_scaleDown, _scaleDefault, _scaleUp, Mathf.Abs(intrepolant) * -1);
            transform.localScale = new Vector2(scale.x, scale.y);
        }
        
        public void SetDefault()
        {
            transform.localScale = _scaleDefault;
        }
        
        private Vector3 Lerp3(Vector3 a, Vector3 b, Vector3 c, float t)
        {
            return t < 0
                ? Vector3.Lerp(a, b, t + 1f)
                : Vector3.Lerp(b, c, t);
        }
    }
}