using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private string gunName;
    private int currentAmmo;
    private int maxAmmo = 10;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public float reloadTime = 1f;
    private bool isReloading = false;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;

    private float nextTimeToFire = 0f;

    private Animator animations;

    private float coolDownTime = 1f;
    private float coolDown;

    public AudioSource bulletShot;


    void Start() {
        animations = GetComponent<Animator>();
        currentAmmo = maxAmmo;
    }

    void Update() {

        if (isReloading)
            return;

        if (Input.GetKeyDown(KeyCode.R)) {
            if (currentAmmo < maxAmmo && currentAmmo > 0) {
                animations.SetBool("Firing", false);
                animations.SetBool("Running", false);

                StartCoroutine(Reload());

                return;
            }
        }

        if (currentAmmo == 0){

            animations.SetBool("Firing", false);
            animations.SetBool("Running", false);

            StartCoroutine(Reload());

            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && isReloading == false) {
            
            animations.SetBool("Firing", true);
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (!Input.GetButton("Fire1"))
        animations.SetBool("Firing", false);

        if (Input.GetKeyDown(KeyCode.W)) {
                animations.SetBool("Running", true); 
        }

        if (Input.GetKeyUp(KeyCode.W)) {
            animations.SetBool("Running", false);
        }

    }

    void Shoot() {

        if (isReloading)
            return;

            RaycastHit hit;

            muzzleFlash.Play();


            if (!bulletShot.isPlaying) { 
                bulletShot.Play();
            }

            currentAmmo--;

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {

                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactObj, 2f);
            }
    }

    IEnumerator Reload() {

        isReloading = true;

        Debug.Log("Reloading.... " + nextTimeToFire);

        animations.SetBool("Reloading", true);

        yield return new WaitForSeconds(coolDownTime + reloadTime - .25f);

        animations.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        isReloading = false;
    }

    public string GetName() {
        return name;
    }

    public int GetCurrentAmmo() {
        return currentAmmo;
    }

    public int GetMaxAmmo() {
        return maxAmmo;
    }
}
