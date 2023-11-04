using UnityEngine;

namespace GameArchi.InputSystem
{
    public interface IInputSetter
    {
        void Bind(InputAction actionType, KeyCode keyCode);
        void Unbind(InputAction actionType);
        void ClearAllBind();
        void UpdateBind(InputAction actionType, KeyCode newKeyCode);
    }
}