using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public int magAmmo;
    private int ReserveAmmount = -1;
    public int totalAmmo = 50;
    public float reloadTime = 1f;

    private bool isReloading = false;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public GameObject impactEffect;

    public Text magText;
    public Text reserveText;

     void Start() {
        {
            ReserveAmmount = magAmmo;
        }
    }
    // Update is called once per frame
    void Update()
    {
        magText.text = ReserveAmmount.ToString();
        reserveText.text = totalAmmo.ToString();

        if (isReloading)
            return;
        if (ReserveAmmount <= 0 || (Input.GetKeyDown("r")))
        {
            StartCoroutine(Reload());
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    IEnumerator Reload ()
    {
        if (totalAmmo > magAmmo){
        isReloading = true;
        

        yield return new WaitForSeconds(reloadTime);

        ReserveAmmount = magAmmo;
        isReloading = false;

        totalAmmo = totalAmmo - ReserveAmmount;

        }
    }
    void Shoot()
    {

        if (ReserveAmmount > 0){
        muzzleFlash.Play();

        ReserveAmmount --;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

           EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();

           if (health != null)

            health.TakeDamage(damage);

        }

        Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
