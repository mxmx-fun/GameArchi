using System;

namespace GameArchi.InputModule {

    public class InputEventCenter{

        public event Action<InputButton> OnInputButtonDownHandler;
        public event Action<InputButton> OnInputButtonUpHandler;
        public event Action<InputButton> OnInputButtonPressedHandler;

        public void OnButtonDown(InputButton button){
            OnInputButtonDownHandler?.Invoke(button);
        }

        public void OnButtonUp(InputButton button){
            OnInputButtonUpHandler?.Invoke(button);
        }

        public void OnButtonPressed(InputButton button){
            OnInputButtonPressedHandler?.Invoke(button);
        }
    }
}