using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //private float damage = 10f;

    private bool canFireNextBullet = true;
    private float fireRate = 0.3f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public GunAudioManager gunAudioManager;
    public Animator animator;
    private int maxAmmo = 30;
    private int currentAmmo = 30;
    private bool IsReloading = false;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canFireNextBullet && !IsReloading)
        {

            if (currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                Reload();
            }
            
        }
        
    }

    private void Shoot()
    {
        currentAmmo--;
        StartCoroutine(waitFireRate());
        muzzleFlash.Play();
        gunAudioManager.Play("Shooting");
        animator.SetTrigger("Shoot");
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit)) {

            Debug.Log(hit.transform.name);


            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1f);


        }
        
        
    }

    IEnumerator waitFireRate()
    {
        canFireNextBullet = false;
        yield return new WaitForSeconds(fireRate);
        canFireNextBullet = true;

    }


    public void StartReloading()
    {
        IsReloading = true;
    }

    public void EndReloading()
    {
        IsReloading = false;
    }

    public void Reload()
    {
        animator.SetTrigger("Reload");
        gunAudioManager.Play("Reloading");
        currentAmmo = maxAmmo;

    }
}
