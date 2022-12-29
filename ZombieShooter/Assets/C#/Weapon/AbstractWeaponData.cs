using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponData : MonoBehaviour
{
    public enum Type
    {
        MeleeWeapon,
        FireWeapon
    }

    [SerializeField] Type weaponType;

    [Header("General")]
    [SerializeField] int id;//id оружия
    [SerializeField] int damage; //урон
    [SerializeField] float speedAttack;//скорострельность

    public int WeaponId => id;
    public int WeaponDamage => damage;
    public float WeaponSpeedAttack => speedAttack;
    public Type WeaponType => weaponType;

    public abstract void Attack();
}
