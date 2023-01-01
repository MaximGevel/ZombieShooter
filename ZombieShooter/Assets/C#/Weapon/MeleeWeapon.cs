using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : AbstractWeaponData
{
    [Header("Melee Weapon")]
    [SerializeField] Transform attackPoint;//����� �����
    [SerializeField] float attackRadius;//������ �����
    [SerializeField] LayerMask layerItCanAttack;//����, � �������� ����� ���������

    float timer = 0;

    public Transform FistPunchPoint => attackPoint;
    public float FistPunchRadius => attackRadius;
    public LayerMask FistLayerItCanHit => layerItCanAttack;

    public override void Attack(Animator animator)
    {
        if(timer <= 0)
        {
            timer = WeaponSpeedAttack;
            animator.SetTrigger("Attack");
        }

    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void Punch()
    {
        Collider[] hitObjects = Physics.OverlapSphere(attackPoint.position, attackRadius, layerItCanAttack);
        if (hitObjects.Length != 0)
        {
            foreach (var obj in hitObjects)
            {
                HealthManager objHP = obj.GetComponent<HealthManager>();
                if (objHP)
                {
                    objHP.TakeDamage(WeaponDamage);
                }
            }
        }
    }
}
