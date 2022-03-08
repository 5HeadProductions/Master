using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// This script translates the mouse movement to camera movement
/// </summary>
public class LookMovement : MonoBehaviour
{

    [SerializeField] float sensitivityX = 8f;
    [SerializeField] float sensitivityY = .5f;
    float cameraX, cameraY;

    [SerializeField]
    private Transform playerCamera;
    [SerializeField]
    private float xClamp = 85f;
    float xRotation = 0f;

    public void Update()
    {
        transform.Rotate(Vector3.up, cameraX * Time.deltaTime);
        xRotation -= cameraY;
        xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }
    public void GetMouseInput(Vector2 mouseInput)
    {
        cameraX = mouseInput.x;// * sensitivityX;
        cameraY = mouseInput.y;// * sensitivityY;
    }
}
