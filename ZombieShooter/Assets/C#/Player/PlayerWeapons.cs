using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] AbstractWeaponData[] fullWeapons;//все оружия, которые могут быть у гг
    [SerializeField] List<AbstractWeaponData> playerWeapons = new List<AbstractWeaponData>();//оружия, которые есть у гг

    private void Start()
    {

    }

    private void Update()
    {

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
                        weaponInPlayer.gameObject.SetActive(true);

                        Destroy(pickUpObj.gameObject);
                    }

                }
            }
        }
        
    }
}

