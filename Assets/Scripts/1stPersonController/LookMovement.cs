using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// This script translates the mouse movement to camera movement
/// When we move the mouse on the x-axis we want to rotate our player on the y-axis
/// When we move the mouse on the y-axis we want to rotate our camera on the x-axis
/// </summary>
public class LookMovement : MonoBehaviour
{

    [SerializeField] 
    private float mouseSensitivity = 100f;
   [HideInInspector] public Vector2 mouseLook;

    [SerializeField]
    private Transform playerCamera;

    float xRotation = 0f;
    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Update()
    {
        float mouseX = mouseLook.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseLook.y * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up, mouseX);
        //Vector3 targetRotation = transform.eulerAngles;
        //targetRotation.x = xRotation;
        //playerCamera.eulerAngles = targetRotation;
    }
}
