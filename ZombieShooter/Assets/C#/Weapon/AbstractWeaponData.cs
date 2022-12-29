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

    [Header("General")]
    [SerializeField] int id;//id оружия
    [SerializeField] int damage; //урон
    [SerializeField] float speedAttack;//скорострельность
    [SerializeField] KeyCode keycodeForActivate;//кнопка для выбора оружия

    public int WeaponId => id;
    public int WeaponDamage => damage;
    public float WeaponSpeedAttack => speedAttack;
    public KeyCode WeaponKeyCodeForActivate => keycodeForActivate;
    public Type WeaponType
    {
        get { return WeaponType; }
        set { WeaponType = value; }
    }

    public abstract void Attack();
}
