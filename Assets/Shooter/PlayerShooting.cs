using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] private float shootRate = 1;
    private float shootDelay = 1;
    private float lastShootTime;

    private void Start()
    {
        shootDelay = 1 / shootRate;
    }

    public void Shoot()
    {
        if(!CanShoot())
        {
            return;
        }

        lastShootTime = Time.time;

        Debug.Log("Shoot");
        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * 20,Color.red);
        if (Physics.Raycast(cameraRay, out RaycastHit hit))
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);
            Health hitHealth = hit.collider.GetComponent<Health>();
            if(hitHealth != null )
            {
                hitHealth.TakeDamage(1);
            }
        }
    }

    private bool CanShoot()
    {
        return Time.time > lastShootTime + shootDelay;
    }
}
