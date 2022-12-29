using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponData : MonoBehaviour
{
    [Header("General")]
    [SerializeField] int id;//id ������
    [SerializeField] int damage; //����
    [SerializeField] float speedAttack;//����������������
    [SerializeField] KeyCode keycodeForActivate;//������ ��� ������ ������

    public int WeaponId => id;
    public int WeaponDamage => damage;
    public float WeaponSpeedAttack => speedAttack;

    public KeyCode WeaponKeyCodeForActivate => keycodeForActivate;

    public abstract void Attack();
}
