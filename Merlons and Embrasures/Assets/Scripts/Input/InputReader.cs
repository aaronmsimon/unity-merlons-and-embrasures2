using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace ME.Input
{
    [CreateAssetMenu(fileName = "InputReader", menuName = "Input Reader")]
    public class InputReader : ScriptableObject, GameInput.IGameplayActions
    {
        // Gameplay
        public event UnityAction mouseLeftClickEvent;

        private GameInput gameInput;

        private Vector2 lastPointerScreenPos;

        private void OnEnable()
        {
            if (gameInput == null)
            {
                gameInput = new GameInput();
                gameInput.Gameplay.SetCallbacks(this);
            }

            EnableGameplayInput();
        }

        private void OnDisable()
        {
            DisableAllInput();
        }

        // Gameplay Events
        public void OnMouseLeftClick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed) {
                mouseLeftClickEvent?.Invoke();
            }
        }

        // Enable/Disable Action Maps
        public void EnableGameplayInput()
        {
            gameInput.Gameplay.Enable();
        }

        public void DisableAllInput()
        {
            gameInput.Gameplay.Disable();
        }
    }
}