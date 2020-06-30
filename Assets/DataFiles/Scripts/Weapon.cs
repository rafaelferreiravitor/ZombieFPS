using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera FPCamera;
    int weaponHit = 10;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitFeedbackVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 2;
    [SerializeField] AmmoType ammoType;
    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(canShoot)
                StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            HitTarget();
            HitVFX();
            ammoSlot.ReduceAmmo(ammoType);
        }
        print("before yield");
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
        print("After yield");

    }

    void HitTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            var impact = Instantiate(hitFeedbackVFX, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact.transform.gameObject,0.1f);

            if (hit.transform.GetComponent<EnemyHealth>())
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.Hit(weaponHit);
            }
        }
        else
        {
            return;
        }
    }

    void HitVFX()
    {

        muzzleFlashVFX.Play();
    }

}
