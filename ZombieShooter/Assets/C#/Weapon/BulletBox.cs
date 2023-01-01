using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBox : MonoBehaviour
{
    [SerializeField] FireWeapon weapon;
    [SerializeField] int amountBulletInBox;

    public FireWeapon Weapon => weapon;
    public int AmountBullet => amountBulletInBox;
}
