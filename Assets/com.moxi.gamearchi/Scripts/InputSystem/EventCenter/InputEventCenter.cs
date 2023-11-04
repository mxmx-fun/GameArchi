using System;

namespace GameArchi.InputSystem {

    public class InputEventCenter{

        public event Action<InputAction> OnInputButtonDownHandler;
        public event Action<InputAction> OnInputButtonUpHandler;
        public event Action<InputAction> OnInputButtonPressedHandler;

        public void OnButtonDown(InputAction button){
            OnInputButtonDownHandler?.Invoke(button);
        }

        public void OnButtonUp(InputAction button){
            OnInputButtonUpHandler?.Invoke(button);
        }

        public void OnButtonPressed(InputAction button){
            OnInputButtonPressedHandler?.Invoke(button);
        }
    }
}