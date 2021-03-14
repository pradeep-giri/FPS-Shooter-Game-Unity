using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 100f;
    public float fireRate = 5f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impectEffect;

    private float nextTimeToFire = 0f;
    
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red);
            //Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impectEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
