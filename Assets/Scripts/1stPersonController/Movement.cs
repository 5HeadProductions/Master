using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script applies all the values that InputManager optains from the player.
/// </summary>
public class Movement : MonoBehaviour
{
    public PlayerStats playerStatsScriptableObject;
    [SerializeField]
    CharacterController characterController;
    public float movementSpeed => playerStatsScriptableObject.movementSpeed;
    public float jumpHeight => playerStatsScriptableObject.jumpHeight;
    public float gravity => playerStatsScriptableObject.gravity;
    public bool jumpPressed;
    Vector3 verticalVelocity = Vector3.zero;
    Vector2 horizontalMovement;
    [SerializeField]
    public LayerMask groundMask;
    public bool isGrounded;
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .1f, groundMask);
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
