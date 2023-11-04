using System.Collections.Generic;
using UnityEngine;

namespace GameArchi.InputSystem
{
    public class InputContext
    {
        public Dictionary<InputAction, KeyCode> inputActions;

        public InputContext()
        {
            inputActions = new Dictionary<InputAction, KeyCode>();
        }

    }
}