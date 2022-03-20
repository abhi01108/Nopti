using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SniperGunScript : MonoBehaviour
{
    public Camera fpsCam;
    public Animator animator;
    public GameObject WeaponHolder;
    public GameObject shotEffect;
    public AudioSource aa;
    public AudioSource noAmmoClip;
    public Text ammotext;
    public Text TotalAmmo;
    public ParticleSystem muzzleFlash;


    private int Maxammo = 10;
    private int MaxTotalammo = 30;
    private int currentAmmo;
    private int TempCurrentAmmo;


    private float reloadTime =2.5f;
    private float fireRate = 1;
    private bool isReloading = false;
    private bool canReload;
    private bool canShoot;


    private float nextTimeToFire = 0f;
    private float damage = 100f;
    private float range = 400f;
    private void Start()
    {
        currentAmmo = Maxammo;
    }
    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;
        if (MaxTotalammo <= 0 || currentAmmo == Maxammo)
        {
            canReload = false;
        }
        else if (MaxTotalammo > 0)
        {
            canReload = true;
        }
        if (currentAmmo <= 0)
        {
            canShoot = false;
            Debug.Log("Out of Ammo");
        }
        else if (currentAmmo > 0)
        {
            canShoot = true;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canShoot)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            muzzleFlash.Play();
            aa.Play();
        }
        if ((currentAmmo <= 0 || (Input.GetKeyDown(KeyCode.R))) && canReload)
        {
            //Play reload animation and input.GetButtonDown("Fire1")=locked and cant shoot

            StartCoroutine(Reload());
            return;
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        isReloading = false;
        if (MaxTotalammo >= Maxammo)
        {
            TempCurrentAmmo = currentAmmo;
            currentAmmo = Maxammo;
            ammotext.text = currentAmmo.ToString();
            MaxTotalammo = MaxTotalammo - (Maxammo - TempCurrentAmmo);
            TotalAmmo.text = MaxTotalammo.ToString();
        }
        else if (MaxTotalammo < Maxammo)
        {
            int AmmoRequired = Maxammo - currentAmmo;
            if (MaxTotalammo < AmmoRequired)
            {
                AmmoRequired = MaxTotalammo;
            }
            currentAmmo = currentAmmo + AmmoRequired;
            ammotext.text = currentAmmo.ToString();
            MaxTotalammo = MaxTotalammo - AmmoRequired;

            TotalAmmo.text = MaxTotalammo.ToString();
        }
    }
    void Shoot()
    {
        currentAmmo--;
        ammotext.text = currentAmmo.ToString();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            GameObject shotEffectInstantiater = Instantiate(shotEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(shotEffectInstantiater, 0.3f);
        }
        //out hit stores the data that is gathered after the ray hits the object
    }
}
