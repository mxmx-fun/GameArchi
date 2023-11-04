using UnityEngine;

namespace GameArchi.InputSystem
{

    public class InputGetter : IInputGetter
    {
        InputDomain domain;

        public void Inject(InputDomain domain)
        {
            this.domain = domain;
        }

        KeyCode IInputGetter.GetKey(InputAction action)
        {
            return domain.GetKey(action);
        }
    }
}