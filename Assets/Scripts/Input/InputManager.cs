using UnityEngine;
using UnityEngine.InputSystem;

namespace Mir.Input
{
    public class InputManager : MonoBehaviour
    {
        // input handling
        private PlayerInput playerInput;

        // movement variables
        private bool isBackPressed = false;
        private bool isInterractionPressed;

        public static InputManager instance { get; private set; }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Input Manager in the scene.");
            }
            instance = this;

            playerInput = new PlayerInput();

            RegisterToEvents();
        }

        private void Start()
        {

        }

        private void OnEnable()
        {
            playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            playerInput.Player.Disable();
        }

        private void RegisterToEvents()
        {
            playerInput.Player.Back.started += BackPressed;

            playerInput.Player.Interracion.started += InterractionPressed;
            playerInput.Player.Interracion.canceled += InterractionPressed;
        }

        private void InterractionPressed(InputAction.CallbackContext context)
        {
            isInterractionPressed = context.ReadValueAsButton();
        }

        private void BackPressed(InputAction.CallbackContext context)
        {
            isBackPressed = context.ReadValueAsButton();
        }

        // for any of the below 'Get' methods, if we're getting it then we're also using it,
        // which means we should set it to false so that it can't be used again until actually
        // pressed again.

        public bool GetBackPressed()
        {
            bool result = isBackPressed;
            isBackPressed = false;
            return result;
        }

        public bool GetInterractionPressed()
        {
            bool result = isInterractionPressed;
            isInterractionPressed = false;
            return result;
        }
    }
}