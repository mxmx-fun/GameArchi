using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameArchi.InputSystem;

public class InputSystemSample : MonoBehaviour
{
    InputSystem inputSystem;

    public void Start()
    {
        //Init
        inputSystem = new InputSystem();
        
        //Bind Input
        inputSystem.SetterAPI.Bind(InputAction.Jump, KeyCode.Space);
        inputSystem.SetterAPI.Bind(InputAction.Attack, KeyCode.J);
        inputSystem.SetterAPI.Bind(InputAction.Chat, KeyCode.E);
        inputSystem.SetterAPI.Bind(InputAction.MoveForward, KeyCode.W);
        inputSystem.SetterAPI.Bind(InputAction.MoveBackward, KeyCode.S);
        inputSystem.SetterAPI.Bind(InputAction.MoveLeft, KeyCode.A);
        inputSystem.SetterAPI.Bind(InputAction.MoveRight, KeyCode.D);
        
        inputSystem.eventCenter.OnInputButtonDownHandler += (button) => {
            if(button == InputAction.Jump){
                Debug.Log("Jump");
            }
            if(button == InputAction.Attack){
                Debug.Log("Attack");
            }
            if(button == InputAction.Chat){
                Debug.Log("Chat");
            }
            if(button == InputAction.MoveForward){
                Debug.Log("MoveForward");
            }
            if(button == InputAction.MoveBackward){
                Debug.Log("MoveBackward");
            }
            if(button == InputAction.MoveLeft){
                Debug.Log("MoveLeft");
            }
            if(button == InputAction.MoveRight){
                Debug.Log("MoveRight");
            }
        };
    }

    public void Update()
    {
        inputSystem.Tick();
    }
}
