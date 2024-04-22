using UnityEngine;
using UnityEngine.InputSystem;

namespace Mir.Input
{
    public class InputManager : MonoBehaviour
    {
        // input handling
        private PlayerInput playerInput;

        private bool isBackPressed = false;
        private bool isInteractionPressed;

        // Player movement variables
        private bool isMovementPressed;
        private Vector3 movement;
        private bool isSlidePressed;
        private bool isJumpPressed;

        // Bottombar variables
        private bool isNextPressed;

        // Gamepad connection
        public bool isGamepad;

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

            playerInput.Player.Back.started += BackPressed; // This event subscribed here because detecteing back pressed must always stay subscirbed.
        }

        private void Start()
        {
            GameEventsManager.instance.onGamePause += UnregisterToEvetns;
            GameEventsManager.instance.onGameResume += RegisterToEvents;

            #region Gamepad Handling
            InputSystem.onDeviceChange += InputUser_onChange;

            GameEventsManager.instance.onGamepadConnected += GamepadConnected;
            GameEventsManager.instance.onGamepadDisconnected += GamepadDisconnected;
            #endregion

            ScanInputDevices();
        }

        private void OnEnable()
        {
            playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            playerInput.Player.Disable();
        }

        #region Gamepad
        private void InputUser_onChange(InputDevice device, InputDeviceChange change)
        {
            Debug.Log("InputDevice Display Name:" + device.name);

            if (device.name.Equals("DualShock4GamepadHID"))
            {
                if ( change == InputDeviceChange.Added || change == InputDeviceChange.Enabled)
                {
                    Debug.Log("Kontrolcü algýlandý: " + device.displayName);

                    if (IsGamepad) Debug.LogWarning("Birden fazla kontrolcü algýlandý.");
                    IsGamepad = true;

                    GameEventsManager.instance.OnGamepadConnected();
                }

                if ( change == InputDeviceChange.Removed || change == InputDeviceChange.Disabled)
                {
                    Debug.Log("Kontrolcü çýkarýldý: " + device.displayName);

                    if (!IsGamepad) Debug.LogError("Bilinmeyen bir hata meydana geldi.");
                    IsGamepad = false;

                    GameEventsManager.instance.OnGamepadDisconnected();
                }
            }

        }

        private void ScanInputDevices()
        {
            // Scan for curretn input (keyboard or gamepad)
            int i = 0;
            foreach (InputDevice device in InputSystem.devices)
            {
                if (device.name.Equals("DualShock4GamepadHID"))
                {
                    IsGamepad = true;
                    i++;

                    if (i > 1)
                    {
                        Debug.Log("Kontrolcü algýlandý: " + device.name);
                        return;
                    }

                    GameEventsManager.instance.OnGamepadConnected();
                }
            }
        }

        private void GamepadConnected()
        {
            
        }

        private void GamepadDisconnected()
        {
            
        }
        #endregion

        private void RegisterToEvents()
        {
            /// playerInput.Player.Back.started is excepted.

            playerInput.Player.Interracion.started += InteractionPressed;
            playerInput.Player.Interracion.canceled += InteractionPressed;

            #region Player Movement
            playerInput.Player.Movement.started += MovementPressed; // On press
            playerInput.Player.Movement.performed += MovementPressed; // While pressing
            playerInput.Player.Movement.canceled += MovementPressed; // End press

            playerInput.Player.Slide.started += SlidePressed; // On slide
            playerInput.Player.Slide.canceled += SlidePressed; // End slide

            playerInput.Player.Jump.started += JumpPressed; // On Jump
            playerInput.Player.Jump.canceled += JumpPressed; // End Jump
            #endregion

            #region Bottom Bar
            playerInput.Player.Next.started += NextPressed;
            #endregion
        }

        private void UnregisterToEvetns()
        {
            /// playerInput.Player.Back.started is excepted.

            playerInput.Player.Interracion.started -= InteractionPressed;
            playerInput.Player.Interracion.canceled -= InteractionPressed;

            playerInput.Player.Movement.started -= MovementPressed; // On press
            playerInput.Player.Movement.performed -= MovementPressed; // While pressing
            playerInput.Player.Movement.canceled -= MovementPressed; // End press

            playerInput.Player.Slide.started -= SlidePressed; // On slide
            playerInput.Player.Slide.canceled -= SlidePressed; // End slide

            playerInput.Player.Jump.started -= JumpPressed; // On Jump
            playerInput.Player.Jump.canceled -= JumpPressed; // End Jump

            playerInput.Player.Next.started -= NextPressed;
        }

        private void InteractionPressed(InputAction.CallbackContext context)
        {
            isInteractionPressed = context.ReadValueAsButton();
        }

        private void BackPressed(InputAction.CallbackContext context)
        {
            isBackPressed = context.ReadValueAsButton();
        }

        private void MovementPressed(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();

            movement.x = movementInput.x;
            movement.y = movementInput.y;

            isMovementPressed = movementInput != Vector2.zero;
        }

        private void SlidePressed(InputAction.CallbackContext context)
        {
            isSlidePressed = context.ReadValueAsButton();
        }

        private void JumpPressed(InputAction.CallbackContext context)
        {
            isJumpPressed = context.ReadValueAsButton();
        }

        private void NextPressed(InputAction.CallbackContext context)
        {
            isNextPressed = context.ReadValueAsButton();
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
            bool result = isInteractionPressed;
            isInteractionPressed = false;
            return result;
        }

        public bool GetMovementPressed()
        {
            bool result = isMovementPressed;
            isMovementPressed = false;
            return result;
        }

        public bool GetSlidePressed()
        {
            bool result = isSlidePressed;
            isSlidePressed = false;
            return result;
        }

        public bool GetJumpPressed()
        {
            bool result = isJumpPressed;
            isJumpPressed = false;
            return result;
        }

        public bool GetNextPressed()
        {
            bool result = isNextPressed;
            isNextPressed = false;
            return result;
        }

        #region Properties

        public Vector3 Movement
        {
            get
            {
                return movement;
            }
        }

        public bool IsGamepad
        {
            get
            {
                return isGamepad;
            }

            private set
            {
                isGamepad = value;
            }
        }

        #endregion

    }
}