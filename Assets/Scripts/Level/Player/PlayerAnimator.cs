using UnityEngine;

namespace Level.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void RunIdle()
        {
            _animator.SetTrigger("Idle");
        }
    }
}