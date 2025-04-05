using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLooking : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200;
    [SerializeField] private float minCameraRotationX = -90;
    [SerializeField] private float maxCameraRotationX = 90;
    [SerializeField] Transform cameraTransform;
    private float currentRotationX;
    public void RotateBody(float horizontalInput)
    {
        transform.Rotate(0, horizontalInput * Time.deltaTime * rotationSpeed, 0);
    }

    public void RotateCamera(float verticalInput)
    {
        currentRotationX -= verticalInput * rotationSpeed * Time.deltaTime;
        currentRotationX = Mathf.Clamp(currentRotationX, minCameraRotationX, maxCameraRotationX);
        cameraTransform.localRotation = Quaternion.Euler(currentRotationX, 0, 0);
    }
}
