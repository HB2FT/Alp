using Mir.Objects.Items;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mir.Entity.Player
{
    public class ItemSystem : MonoBehaviour
    {
        private PlayerInput playerInput;
        private Item currentItem;
        private readonly Item[] items = { new Hand(), new Sword() };

        public int currentItemIndex;

        public bool isAttackPressed;

        private void Awake()
        {
            playerInput = new PlayerInput();

            playerInput.Player.Attack.started += Attack;
            playerInput.Player.ItemIndex.started += OnItemChanged;
        }

        void Start()
        {
            playerInput = new PlayerInput();
            currentItem = new Hand();
        }

        void Update()
        {
            
        }

        void OnItemChanged(InputAction.CallbackContext context)
        {
            Vector2 vector = context.ReadValue<Vector2>();

            int delta = (int)vector.y;

            currentItemIndex += delta;

            if (currentItemIndex >= items.Length)
            {
                currentItemIndex = items.Length - 1;
                return;
            }

            else if (currentItemIndex < 0)
            {
                currentItemIndex = 0;
                return;
            }

            currentItem = items[currentItemIndex];
        }

        void Attack(InputAction.CallbackContext context)
        {
            //isAttackPressed = context.ReadValueAsButton();

            currentItem.OnUse();
        }

        private void OnEnable()
        {
            playerInput.Player.Enable();
        }

        private void OnDisable()
        {
            playerInput.Player.Disable();
        }

        public Item CurrentItem
        {
            get 
            { 
                return currentItem; 
            } 
        }
    }
}
