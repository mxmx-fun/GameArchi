using UnityEngine;

namespace GameArchi.InputModule
{
    public class InputSetter : IInputSetter
    {
        InputDomain domain;

        public void Inject(InputDomain domain)
        {
            this.domain = domain;
        }

        void IInputSetter.Bind(InputButton actionType, KeyCode keyCode)
        {
            domain.Bind(actionType, keyCode);
        }

        void IInputSetter.ClearAllBind()
        {
            domain.ClearAllBind();
        }

        void IInputSetter.Unbind(InputButton actionType)
        {
            domain.Unbind(actionType);
        }

        void IInputSetter.UpdateBind(InputButton actionType, KeyCode newKeyCode)
        {
            domain.UpdateBind(actionType, newKeyCode);
        }
    }

}