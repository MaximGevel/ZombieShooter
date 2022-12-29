using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] int id;

    [SerializeField] int damage; //урон
    [SerializeField] int amountButtonAtShoot;//колво пуль при стрельбе
    [SerializeField] int amountBulletInMagazine;//колво пуль в магазине

    [SerializeField] float reloadTime;//время перезaрядки
    [SerializeField] float speedAttack;//скорострельность
    [SerializeField] float bulletRangeScatter;//разброс пуль

    public int WeaponId => id;

    public int WeaponDamage => damage;
    public int WeaponAmountBulletInMagazine => amountBulletInMagazine;
    public int WeaponAmountButtonsAtShoot => amountButtonAtShoot;

    public float WeaponReloadTime => reloadTime;
    public float WeaponSpeedAttack => speedAttack;
    public float WeaponBulletRangeScatter => bulletRangeScatter;
}
