using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBox : MonoBehaviour
{
    [SerializeField] int healtRegen;
    public int HealthRegen => healtRegen;

    public void RegenHealth(HealthManager healthManager)
    {
        healthManager.Health += HealthRegen;
        Destroy(gameObject);
    }
}
