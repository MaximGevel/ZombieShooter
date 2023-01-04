using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth playerHealth;
    
    [SerializeField] Slider hpBar;

    HealthManager healthManager;

    private void Awake()
    {
        playerHealth = this;
    }

    private void Start()
    {
        if (!healthManager)
            healthManager = GetComponent<HealthManager>();

        UpdateHPBar();
    }

    public static void PlayerRegenHealth(int regenHp)
    {
        playerHealth.healthManager.Health += regenHp;
        playerHealth.UpdateHPBar();
    }

    public static void PlayerTakeDamage(int damage)
    {
        playerHealth.healthManager.Health -= damage;
        playerHealth.UpdateHPBar();
    }

    void UpdateHPBar()
    {
        hpBar.value = healthManager.Health;
    }

    private void OnTriggerEnter(Collider other)
    {
        MinusTrigger test = other.GetComponent<MinusTrigger>();
        if (test)
        {
            healthManager.Health -= test.Hp;
            UpdateHPBar();
        }

        MedicineBox medicineBox = other.GetComponent<MedicineBox>();
        if (medicineBox)
        {
            medicineBox.RegenHealth(healthManager);
            UpdateHPBar();
        }
    }
}
