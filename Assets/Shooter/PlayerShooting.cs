using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Transform weaponParent;
    [SerializeField] List<Weapon> weapons;
    public int currentWeaponIndex;

    private void Start()
    {
        weaponParent.rotation = Camera.main.transform.rotation;
    }

    public void ChangeWeapon(int index)
    {
        weapons[currentWeaponIndex].gameObject.SetActive(false);
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    public void ChangeToNextWeapon()
    {
        int targetIndex = currentWeaponIndex;
        targetIndex++;
        if(targetIndex >= weapons.Count)
        {
            targetIndex = 0;
        }

        ChangeWeapon(targetIndex);
    }

    public void ChangeToPreviousWeapon()
    {
        int targetIndex = currentWeaponIndex;
        targetIndex--;
        if (targetIndex < 0)
        {
            targetIndex = weapons.Count -1;
        }
        ChangeWeapon(targetIndex);
    }

    public void Shoot()
    {
        weapons[currentWeaponIndex].Shoot();
    }


}
