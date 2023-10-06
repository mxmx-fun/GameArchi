using System.Collections.Generic;
using UnityEngine;

namespace GameArchi.InputSystem
{
    public class InputContext
    {
        public Dictionary<InputButton, KeyCode> inputActions;

        public InputContext()
        {
            inputActions = new Dictionary<InputButton, KeyCode>();
        }

    }
}