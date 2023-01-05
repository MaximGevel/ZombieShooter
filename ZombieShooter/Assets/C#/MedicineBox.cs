using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBox : MonoBehaviour
{
    [SerializeField] int healtRegen;
    [SerializeField] GameObject[] heartEf;

    public int HealthRegen => healtRegen;

    public void RegenHealth(HealthManager healthManager)
    {
        healthManager.Health += HealthRegen;
        for (int i = 0; i < heartEf.Length; i++)
        {
            Instantiate(heartEf[i], transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}
