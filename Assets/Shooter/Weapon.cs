using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float shootRate = 1;
    [SerializeField] protected int damage = 1;
    private float shootDelay = 1;
    private float lastShootTime;

    [SerializeField] WeaponStats weaponStats;


    private void Start()
    {
        shootDelay = 1 / shootRate;
    }

    public virtual bool Shoot()
    {
        if (!CanShoot())
        {
            return false;
        }

        lastShootTime = Time.time;
        return true;


       // ShootWeaponType();

        //if(weaponType == WeaponType.Raycast)
        //{
        //    ShootRaycast();
        //}
        //else if(weaponType == WeaponType.Projectile)
        //{
        //    ShootProjectile();
        //}
    }

    //protected virtual void ShootWeaponType()
    //{
    //    // 
    //}

    private bool CanShoot()
    {
        return Time.time > lastShootTime + shootDelay;
    }

    private void ShootProjectile()
    {
        
    }
}
