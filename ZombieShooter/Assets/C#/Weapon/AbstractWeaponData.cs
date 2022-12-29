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
    [SerializeField] int id;//id ������
    [SerializeField] int damage; //����
    [SerializeField] float speedAttack;//����������������
    [SerializeField] KeyCode keycodeForActivate;//������ ��� ������ ������

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
