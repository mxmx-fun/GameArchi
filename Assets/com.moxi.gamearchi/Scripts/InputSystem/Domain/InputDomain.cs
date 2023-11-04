using UnityEngine;

namespace GameArchi.InputSystem
{
    public class InputDomain
    {
        InputContext context;
        InputEventCenter eventCenter;

        public void Inject(InputContext context, InputEventCenter eventCenter)
        {
            this.context = context;
            this.eventCenter = eventCenter;
        }

        public void Bind(InputAction actionType, KeyCode keyCode)
        {
            var inputActions = context.inputActions;
            if (!inputActions.ContainsKey(actionType))
            {
                inputActions.Add(actionType, keyCode);
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning("Add Action Failed! Input action already exists!");
#endif
            }
        }

        public void Unbind(InputAction actionType)
        {
            var inputActions = context.inputActions;
            if (inputActions.ContainsKey(actionType))
            {
                inputActions.Remove(actionType);
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning("Remove Action Failed! Input action does not exist!");
#endif
            }
        }

        public void ClearAllBind()
        {
            var inputActions = context.inputActions;
            inputActions.Clear();
#if UNITY_EDITOR
            Debug.Log("Clear Actions!");
#endif
        }

        public void UpdateBind(InputAction actionType, KeyCode newKeyCode)
        {
            var inputActions = context.inputActions;
            if (inputActions.ContainsKey(actionType))
            {
                inputActions[actionType] = newKeyCode;
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning("Update Action Failed! Input action does not exist!");
#endif
            }
        }

        public KeyCode GetKey(InputAction actionType)
        {
            var inputActions = context.inputActions;
            if (inputActions.ContainsKey(actionType))
            {
                return inputActions[actionType];
            }
            else
            {
#if UNITY_EDITOR
                Debug.LogWarning($"Cant find the key of {actionType}!");
#endif
                return KeyCode.None;
            }
        }

        public void Tick()
        {
            var inputActions = context.inputActions;
            if (inputActions == null) return;
            foreach (var inputAction in inputActions)
            {
                if (Input.GetKeyDown(inputAction.Value))
                {
                    eventCenter.OnButtonDown(inputAction.Key);
                }
                if (Input.GetKeyUp(inputAction.Value))
                {
                    eventCenter.OnButtonUp(inputAction.Key);
                }
                if (Input.GetKey(inputAction.Value))
                {
                    eventCenter.OnButtonPressed(inputAction.Key);
                }
            }
        }
    }
}