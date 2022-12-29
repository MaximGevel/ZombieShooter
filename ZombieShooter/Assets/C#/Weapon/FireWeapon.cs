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

    float timer;
    int currentAmountBullet;
    bool isReload;

    public float WeaponReloadTime => reloadTime;
    public float WeaponBulletRangeScatter => bulletRangeScatter;
    public int WeaponAmountBulletInMagazine => amountBulletInMagazine;

    private void Start()
    {
        if (camera == null)
            camera = GameObject.FindObjectOfType<Camera>();

        if(currentAmountBullet <= 0)
        {
            currentAmountBullet = WeaponAmountBulletInMagazine;
        }
        
        GameManager.UpdateBulletTxt(currentAmountBullet, WeaponAmountBulletInMagazine);
    }

    public override void Attack()
    {
        Debug.Log("Shoot");
        timer = WeaponSpeedAttack;

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

            Debug.Log(hit.collider.name);
            StartCoroutine(SphereIndicator(hit.point));
        }
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if(currentAmountBullet > 0)
            {
                if(!isReload && timer <= 0)
                {
                    Attack();
                    GameManager.UpdateBulletTxt(currentAmountBullet, WeaponAmountBulletInMagazine);
                }
            }
            else
            {
                WeaponReload();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReload)
        {
            WeaponReload();

        }
    }

    void WeaponReload()
    {
        isReload = true;

        StartCoroutine(IEWeaponReload(WeaponReloadTime));
    }

    IEnumerator IEWeaponReload(float timer)
    {
        while(timer > 0)
        {
            timer--;
            if(timer <= 0)
            {
                currentAmountBullet = WeaponAmountBulletInMagazine;
                GameManager.UpdateBulletTxt(currentAmountBullet, WeaponAmountBulletInMagazine);
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
