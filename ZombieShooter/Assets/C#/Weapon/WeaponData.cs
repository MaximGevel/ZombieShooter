using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] int id;

    [SerializeField] int damage; //����
    [SerializeField] int amountButtonAtShoot;//����� ���� ��� ��������
    [SerializeField] int amountBulletInMagazine;//����� ���� � ��������

    [SerializeField] float reloadTime;//����� �����a�����
    [SerializeField] float speedAttack;//����������������
    [SerializeField] float bulletRangeScatter;//������� ����

    public int WeaponId => id;

    public int WeaponDamage => damage;
    public int WeaponAmountBulletInMagazine => amountBulletInMagazine;
    public int WeaponAmountButtonsAtShoot => amountButtonAtShoot;

    public float WeaponReloadTime => reloadTime;
    public float WeaponSpeedAttack => speedAttack;
    public float WeaponBulletRangeScatter => bulletRangeScatter;
}
