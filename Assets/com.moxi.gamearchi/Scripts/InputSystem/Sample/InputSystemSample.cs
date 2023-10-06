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
        inputSystem.Inject();
        
        //Bind Input
        inputSystem.Setter.Bind(InputButton.Jump, KeyCode.Space);
        inputSystem.Setter.Bind(InputButton.Attack, KeyCode.J);
        inputSystem.Setter.Bind(InputButton.Chat, KeyCode.E);
        inputSystem.Setter.Bind(InputButton.MoveForward, KeyCode.W);
        inputSystem.Setter.Bind(InputButton.MoveBackward, KeyCode.S);
        inputSystem.Setter.Bind(InputButton.MoveLeft, KeyCode.A);
        inputSystem.Setter.Bind(InputButton.MoveRight, KeyCode.D);
        
        inputSystem.eventCenter.OnInputButtonDownHandler += (button) => {
            if(button == InputButton.Jump){
                Debug.Log("Jump");
            }
            if(button == InputButton.Attack){
                Debug.Log("Attack");
            }
            if(button == InputButton.Chat){
                Debug.Log("Chat");
            }
            if(button == InputButton.MoveForward){
                Debug.Log("MoveForward");
            }
            if(button == InputButton.MoveBackward){
                Debug.Log("MoveBackward");
            }
            if(button == InputButton.MoveLeft){
                Debug.Log("MoveLeft");
            }
            if(button == InputButton.MoveRight){
                Debug.Log("MoveRight");
            }
        };
    }

    public void Update()
    {
        inputSystem.Tick();
    }
}
