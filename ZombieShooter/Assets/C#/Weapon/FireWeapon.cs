using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : AbstractWeaponData
{
    Camera camera;

    [Header("Fire Weapon")]
    [SerializeField] int amountBulletInMagazine;//колво пуль в магазине
    [SerializeField] float reloadTime;//время перезaрядки
    [SerializeField] float bulletRangeScatter;//разброс пуль

    [Header("Effects")]
    [SerializeField] GameObject hitEffect;

    float timer;
    int currentAmountBullet;
    bool isReload;
    int spareBullet = 0;

    public float WeaponReloadTime => reloadTime;
    public float WeaponBulletRangeScatter => bulletRangeScatter;
    public int WeaponAmountBulletInMagazine => amountBulletInMagazine;
    public int WeaponCurrentAmountBullet => currentAmountBullet;
    public bool WeaponIsReload => isReload;
    public int WeaponSpareBullet
    {
        get { return spareBullet; }
        set { spareBullet = value; }
    }

    private void Start()
    {
        if (camera == null)
            camera = GameObject.FindObjectOfType<Camera>();

        if(currentAmountBullet <= 0)
        {
            currentAmountBullet = WeaponAmountBulletInMagazine;
        }
        
        GameManager.UpdateBulletTxt(this);
        timer = 0;
    }

    public override void Attack(Animator animator)
    {
        if (currentAmountBullet > 0)
        {
            if (!isReload && timer <= 0)
            {
                Debug.Log("Shoot");
                timer = WeaponSpeedAttack;
                animator.SetTrigger("Attack");

                RaycastHit hit;
                if (Physics.Raycast(camera.transform.position,
                    camera.transform.forward + (Random.insideUnitSphere * (WeaponBulletRangeScatter / 10)), out hit))
                {
                    HealthManager healthManager = hit.collider.GetComponent<HealthManager>();
                    if (healthManager)
                    {
                        healthManager.TakeDamage(WeaponDamage);
                    }
                    
                    currentAmountBullet--;

                    Instantiate(hitEffect, hit.point, Quaternion.identity);
                }

                GameManager.UpdateBulletTxt(this);
            }
        }
        else
        {
            WeaponReload();
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;
    }

    public void WeaponReload()
    {
        if (!isReload)
        {
            isReload = true;
            GameManager.UpdateBulletTxt(this);
            StartCoroutine(IEWeaponReload(WeaponReloadTime));
        }
    }

    IEnumerator IEWeaponReload(float timer)
    {
        while(timer > 0)
        {
            timer--;
            if(timer <= 0)
            {
                if(spareBullet >= WeaponAmountBulletInMagazine)
                {
                    spareBullet -= WeaponAmountBulletInMagazine;
                    currentAmountBullet = WeaponAmountBulletInMagazine;
                }else
                {
                    currentAmountBullet = spareBullet;
                    spareBullet -= spareBullet;
                }
               
                GameManager.UpdateBulletTxt(this);
                isReload = false;

                break;
            }

            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
