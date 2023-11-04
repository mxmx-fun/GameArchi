using UnityEngine;

namespace GameArchi.InputSystem
{
    public interface IInputGetter
    {
        KeyCode GetKey(InputAction action);
    }
}