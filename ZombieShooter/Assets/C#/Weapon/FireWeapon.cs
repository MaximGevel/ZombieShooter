using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : AbstractWeaponData
{
    Camera camera;

    [Header("Fire Weapon")]
    [SerializeField] int amountButtonAtShoot;//колво пуль при стрельбе
    [SerializeField] int amountBulletInMagazine;//колво пуль в магазине
    [SerializeField] float reloadTime;//время перезaрядки
    [SerializeField] float bulletRangeScatter;//разброс пуль

    public float WeaponReloadTime => reloadTime;
    public float WeaponBulletRangeScatter => bulletRangeScatter;
    public int WeaponAmountBulletInMagazine => amountBulletInMagazine;
    public int WeaponAmountButtonsAtShoot => amountButtonAtShoot;

    private void Start()
    {
        if (camera == null)
            camera = GameObject.FindObjectOfType<Camera>();
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    /*public void WeaponShoot()
    {
        for (int i = 0; i < weapon.WeaponAmountButtonsAtShoot; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, 
                camera.transform.forward + (Random.insideUnitSphere * (weapon.WeaponBulletRangeScatter / 10)), out hit))
            {

                HealthManager healthManager = hit.collider.GetComponent<HealthManager>();
                if (healthManager)
                {
                    healthManager.TakeDamage(weapon.WeaponDamage);
                }

                Debug.Log(hit.collider.name);
                StartCoroutine(SphereIndicator(hit.point));
            }
        }
    }*/

    /*void WeaponReload()
    {
    isReload = true;

    StartCoroutine(IEWeaponReload(weapon.WeaponReloadTime));
    }*/

    /*IEnumerator IEWeaponReload(float timer)
    {
        while(timer > 0)
        {
            timer--;
            if(timer <= 0)
            {
                currentAmountBulletInMagazine = weapon.WeaponAmountBulletInMagazine;
                isReload = false;

                break;
            }

            yield return new WaitForSeconds(1);
        }
    }*/

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}
