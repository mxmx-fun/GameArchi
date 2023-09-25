using UnityEngine;

namespace GameArchi.InputModule
{
    public interface IInputSetter
    {
        void Bind(InputButton actionType, KeyCode keyCode);
        void Unbind(InputButton actionType);
        void ClearAllBind();
        void UpdateBind(InputButton actionType, KeyCode newKeyCode);
    }
}