using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : AbstractWeaponData
{
    [Header("Melee Weapon")]
    [SerializeField] Transform attackPoint;//точка удара
    [SerializeField] float attackRadius;//радиус удара
    [SerializeField] LayerMask layerItCanAttack;//слои, с которыми можно атакавать

    public Transform FistPunchPoint => attackPoint;
    public float FistPunchRadius => attackRadius;
    public LayerMask FistLayerItCanHit => layerItCanAttack;

    public override void Attack(Animator animator)
    {
        animator.SetTrigger("Attack");
        Debug.Log("Punch");
    }

    /*public void Punch()
{
    Collider[] hitObjects = Physics.OverlapSphere(fist.FistPunchPoint.position, fist.FistPunchRadius, fist.FistLayerItCanHit);
    if (hitObjects.Length != 0)
    {
        foreach (var obj in hitObjects)
        {
            HealthManager objHP = obj.GetComponent<HealthManager>();
            if (objHP)
            {
                objHP.TakeDamage(fist.FistDamage);
            }
        }
    }
}*/
}
