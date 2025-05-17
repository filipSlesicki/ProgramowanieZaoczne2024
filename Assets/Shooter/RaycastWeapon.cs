using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon
{
    [SerializeField] Camera playerCamera;
    [SerializeField] GameObject hitParticles;
    [SerializeField] WeaponType weaponType;

    public override bool Shoot()
    {
        if(!base.Shoot())
        {
            return false;
        }

        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * 20, Color.red);
        if (Physics.Raycast(cameraRay, out RaycastHit hit))
        {
            Quaternion particlesRotation = Quaternion.LookRotation(hit.normal);
            GameObject spawnedParticles = Instantiate(hitParticles, hit.point, particlesRotation);
            Destroy(spawnedParticles, 10);
            Debug.Log("Hit " + hit.collider.gameObject.name);
            Health hitHealth = hit.collider.GetComponent<Health>();
            if (hitHealth != null)
            {
                hitHealth.TakeDamage(damage);
            }
        }
        return true;
    }
}
