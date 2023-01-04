using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int health;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    private void Update()
    {
        if (health > maxHealth)
            health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            ObjectDie();
    }

    void ObjectDie()
    {
        Debug.Log(gameObject.name + " Die");
        Destroy(gameObject);
    }
}
