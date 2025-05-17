using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPosition;

    public override bool Shoot()
    {
        if(! base.Shoot())
        {
            return false;
        }

        Instantiate(bullet, shootPosition.position, shootPosition.rotation);
        return true;
    }
}
