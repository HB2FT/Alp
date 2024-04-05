using UnityEngine;
using UnityInput = UnityEngine.Input;

namespace Mir.Entity.PlayerUtilities
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        public Animator animator;

        private bool canRecieveInput;
        private bool inputRecieved;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (UnityInput.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack1");
            }
        }
    }

}