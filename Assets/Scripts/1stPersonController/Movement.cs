using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script applies all the values that InputManager optains from the player.
/// </summary>
public class Movement : MonoBehaviour
{
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    public float movementSpeed = 10f;
    [SerializeField]
    public float jumpHeight = 10;
    public bool jumpPressed;
    [SerializeField]
    public float gravity = -9.81f;
    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalMovement;
    [SerializeField]
    public LayerMask groundMask;
    public bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .1f, groundMask);
        //condition ? consequence : alternative
        if (isGrounded) verticalVelocity.y = 0;
        Vector3 horizontalVelocity = (transform.right * horizontalMovement.x + transform.forward * horizontalMovement.y) * movementSpeed;
        characterController.Move(horizontalVelocity * Time.deltaTime);

        if (jumpPressed)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jumpPressed = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        characterController.Move(verticalVelocity * Time.deltaTime);


    }

    public void GetHorizontalMovement(Vector2 horizontalInput)
    {
        horizontalMovement = horizontalInput; // make this into a getter that references input manager
    }

    public void OnJumpPressed()
    {
        jumpPressed = true;
    }
}
