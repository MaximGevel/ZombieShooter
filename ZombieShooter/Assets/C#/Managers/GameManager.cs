using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    [SerializeField] Text bulletTxt;

    private void Awake()
    {
        gameManager = this;
    }

    public static void UpdateBulletTxt(AbstractWeaponData weapon)
    {
        if(weapon.WeaponType == AbstractWeaponData.Type.FireWeapon)
        {
            FireWeapon fWeapon = weapon.GetComponent<FireWeapon>();
            if (!fWeapon.WeaponIsReload)
            {
                int amountBullet = fWeapon.WeaponCurrentAmountBullet;
                int maxBullet = fWeapon.WeaponAmountBulletInMagazine;

                gameManager.bulletTxt.text = amountBullet + "/" + maxBullet;
            }
            else
            {
                gameManager.bulletTxt.text = "reload...";
            }

            
        }else
        {
            gameManager.bulletTxt.text = "";
        }
        
    }
}
