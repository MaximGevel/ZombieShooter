using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] AbstractWeaponData[] fullWeapons;//все оружия, которые могут быть у гг
    [SerializeField] List<AbstractWeaponData> playerWeapons = new List<AbstractWeaponData>();//оружия, которые есть у гг
    [SerializeField] AbstractWeaponData activeWeapon;
    public AbstractWeaponData ActiveWeapon => activeWeapon;

    private void Start()
    {
        ActivateWeapons();
    }

    private void Update()
    {
        SwitchWeapon();

        /*if (Input.GetMouseButtonDown(0))
        {
            if(activeWeapon.WeaponType == AbstractWeaponData.Type.FireWeapon)
            {
                activeWeapon.Attack();
            }
        }*/

        
    }

    void SwitchWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var weapon in playerWeapons)
            {
                if(weapon.WeaponId == 0)
                {
                    activeWeapon = weapon;
                }
            }

        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var weapon in playerWeapons)
            {
                if (weapon.WeaponId == 1)
                {
                    activeWeapon = weapon;
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (var weapon in playerWeapons)
            {
                if (weapon.WeaponId == 2)
                {
                    activeWeapon = weapon;
                }
            }
        }

        ActivateWeapons();
    }

    void ActivateWeapons()
    {
        foreach (var weapon in playerWeapons)
        {
            if(activeWeapon.WeaponId == weapon.WeaponId)
            {
                activeWeapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        PickUpObjects pickUpObj = other.GetComponent<PickUpObjects>();
        
        if (pickUpObj)
        {
            AbstractWeaponData weapon = pickUpObj.PickUpObject.GetComponent<AbstractWeaponData>();

            if (weapon && Input.GetKeyDown(KeyCode.F))
            {
                foreach (var weaponInPlayer in fullWeapons)
                {
                    if (weapon.WeaponId == weaponInPlayer.WeaponId)
                    {
                        playerWeapons.Add(weaponInPlayer);
                        activeWeapon = weaponInPlayer;
                        ActivateWeapons();

                        Destroy(pickUpObj.gameObject);
                    }

                }
            }
        }
        
    }
}

