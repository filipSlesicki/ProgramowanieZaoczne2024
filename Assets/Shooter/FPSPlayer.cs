using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerShooting), typeof(PlayerMovement), typeof(PlayerLooking))]
public class FPSPlayer : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerLooking playerLooking;
    private PlayerShooting playerShooting;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMovement = GetComponent<PlayerMovement>();
        playerLooking = GetComponent<PlayerLooking>();
        playerShooting = GetComponent<PlayerShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movementInput = (new Vector3(horizontalInput, 0, verticalInput)).normalized;// * movementSpeed * Time.deltaTime;
        Vector3 movementVector = transform.forward * movementInput.z + transform.right * movementInput.x;
        playerMovement.Move(movementVector);

        float mouseHorizontalInput = Input.GetAxisRaw("Mouse X");
        float mouseVerticalInput = Input.GetAxisRaw("Mouse Y");
        playerLooking.RotateBody(mouseHorizontalInput);
        playerLooking.RotateCamera(mouseVerticalInput);

        if(Input.GetButton("Fire1"))
        {
            playerShooting.Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerShooting.ChangeWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            playerShooting.ChangeWeapon(1);
        }

        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        if(scrollValue > 0)
        {
            playerShooting.ChangeToNextWeapon();
        }
        if (scrollValue < 0)
        {
            playerShooting.ChangeToPreviousWeapon();
        }
    }
}
