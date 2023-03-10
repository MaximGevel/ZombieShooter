using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] AbstractWeaponData[] fullWeapons;//??? ??????, ??????? ????? ???? ? ??
    [SerializeField] List<AbstractWeaponData> playerWeapons = new List<AbstractWeaponData>();//??????, ??????? ???? ? ??
    [SerializeField] AbstractWeaponData activeWeapon;//???????? ??????
    public AbstractWeaponData ActiveWeapon => activeWeapon;

    Animator animator;

    private void Start()
    {
        if(animator == null)
        {
             animator = GetComponent<Animator>();
        }

        ActivateWeapons();

    }

    private void Update()
    {
        SwitchWeapon();

        if (Input.GetMouseButton(0))
        {
            activeWeapon.Attack(animator);
        }

        if (Input.GetKeyDown(KeyCode.R) && activeWeapon.WeaponType == AbstractWeaponData.Type.FireWeapon )
        {
            activeWeapon.GetComponent<FireWeapon>().WeaponReload();
        }
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
                //activeWeapon.gameObject.SetActive(true);
                animator.SetInteger("Weapon", activeWeapon.WeaponId);
                GameManager.UpdateBulletTxt(activeWeapon);

            }
            else
            {
                //weapon.gameObject.SetActive(false);
            }
        }

        
    }

    public void PunchAttack()
    {
        if(activeWeapon.WeaponType == AbstractWeaponData.Type.MeleeWeapon)
        {
            activeWeapon.GetComponent<MeleeWeapon>().Punch();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PickUpObjects pickUpObj = other.GetComponent<PickUpObjects>();

        if (pickUpObj)
        {
            AbstractWeaponData weapon = pickUpObj.PickUpObject.GetComponent<AbstractWeaponData>();

            if (weapon)
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

        BulletBox bulletBox = other.GetComponent<BulletBox>();
        if (bulletBox && activeWeapon.WeaponType == AbstractWeaponData.Type.FireWeapon)
        {
            FireWeapon weapon = activeWeapon.GetComponent<FireWeapon>();
            if (bulletBox.Weapon.WeaponId == weapon.WeaponId)
            {
                weapon.WeaponSpareBullet += bulletBox.AmountBullet;
                GameManager.UpdateBulletTxt(weapon);
                Destroy(bulletBox.gameObject);
            }
        }
    }
}

