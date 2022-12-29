using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] Weapon[] fullWeapons;//все оружия, которые могут быть у гг
    [SerializeField] List<Weapon> playerWeapons = new List<Weapon>();//оружия, которые есть у гг
    [SerializeField] Fist playerFist;
     
    int currentAmountBulletInMagazine;
    float timeForShoot = 0;
    bool isReload = false;

    Camera camera;

    private void Start()
    {
        if(camera == null)
            camera = GameObject.FindObjectOfType<Camera>();
 

        /*if(weapon != null)
        {
            currentAmountBulletInMagazine = weapon.WeaponAmountBulletInMagazine;
        }*/
    }

    private void Update()
    {
        timeForShoot -= Time.deltaTime;

        if(Input.GetMouseButton(0))
        {
            /*if (!isReload)
            {
                if (currentAmountBulletInMagazine > 0)
                {
                    if (timeForShoot <= 0)
                    {
                        timeForShoot = weapon.WeaponSpeedAttack;

                        WeaponShoot();
                        currentAmountBulletInMagazine -= 1;
                    }
                }
                else
                {
                    WeaponReload();
                }
            }*/

        }

        /*if (Input.GetKeyDown(KeyCode.R) && currentAmountBulletInMagazine < weapon.WeaponAmountBulletInMagazine && !isReload)
        {
            WeaponReload();
        }*/
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
    }

    void WeaponReload()
    {
        isReload = true;

        StartCoroutine(IEWeaponReload(weapon.WeaponReloadTime));
    }*/

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

    private void OnTriggerStay(Collider other)
    {
        PickUpObjects pickUpObj = other.GetComponent<PickUpObjects>();
        Weapon weapon = pickUpObj.PickUpObject.GetComponent<Weapon>();

        if (weapon && Input.GetKeyDown(KeyCode.F))
        {
            foreach (var weaponInPlayer in fullWeapons)
            {
                if(weapon.WeaponData.WeaponId == weaponInPlayer.WeaponData.WeaponId)
                {
                    playerWeapons.Add(weaponInPlayer);
                    weaponInPlayer.gameObject.SetActive(true);

                    Destroy(pickUpObj.gameObject);
                }
            }
        }
    }
}

[System.Serializable]
public class Fist
{
    [Header("Punch")]
    [SerializeField] int damage;//урон
    [SerializeField] float impactSpeed;//скорость удара

    public int FistDamage => damage;
    public float FistImpactSpeed => impactSpeed;

    [Space(10)]
    [SerializeField] Transform punchPoint;//точка удара
    [SerializeField] float punchRadius;//радиус удара
    [SerializeField] LayerMask layerItCanHit;//слои, с которыми можно "драться"

    public Transform FistPunchPoint => punchPoint;
    public float FistPunchRadius => punchRadius;
    public LayerMask FistLayerItCanHit => layerItCanHit;

}
