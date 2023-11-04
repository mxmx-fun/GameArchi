using UnityEngine;

namespace GameArchi.InputSystem
{
    public class InputSetter : IInputSetter
    {
        InputDomain domain;

        public void Inject(InputDomain domain)
        {
            this.domain = domain;
        }

        void IInputSetter.Bind(InputAction actionType, KeyCode keyCode)
        {
            domain.Bind(actionType, keyCode);
        }

        void IInputSetter.ClearAllBind()
        {
            domain.ClearAllBind();
        }

        void IInputSetter.Unbind(InputAction actionType)
        {
            domain.Unbind(actionType);
        }

        void IInputSetter.UpdateBind(InputAction actionType, KeyCode newKeyCode)
        {
            domain.UpdateBind(actionType, newKeyCode);
        }
    }

}