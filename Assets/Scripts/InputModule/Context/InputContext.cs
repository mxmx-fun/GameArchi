using System.Collections.Generic;
using UnityEngine;

namespace GameArchi.InputModule
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