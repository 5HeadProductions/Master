using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Communicates with the input system. 
/// Relays all values to Movement.cs
/// </summary>
public class InputManager : MonoBehaviour
{
    //InputActions script name
    PlayerMovement playerInput;
    [SerializeField]
    Movement movement;
    [SerializeField]
    LookMovement lookMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;
    public void Awake()
    {
        playerInput = new PlayerMovement(); // instance
        playerInput.Enable();
        playerInput.Player.Movement.performed += SetHorizontalInput;
        playerInput.Player.Jump.performed += context => movement.OnJumpPressed();
        playerInput.Player.Look.performed += context => mouseInput = context.ReadValue<Vector2>();
    }
    public void Update()
    {
        movement.GetHorizontalMovement(horizontalInput);
        lookMovement.mouseLook = mouseInput;
    }
    public void SetHorizontalInput(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>(); // x and z coordinates the player is moving
    }

    public void OnDestroy()
    {
        playerInput.Disable();
    }
}
