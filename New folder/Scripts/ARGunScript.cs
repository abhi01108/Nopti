using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class  ARGunScript : MonoBehaviour
{
    public Camera fpsCam;
    public Animator animator;
    public GameObject WeaponHolder;
    public AudioSource aa;
    public Text ammotext;
    public Text TotalAmmo;
    public ParticleSystem muzzleFlash;

    public int Maxammo = 10;
    public int currentAmmo;
    public int tempAmmo=0;

    public int Totalammo = 90;

    public float reloadTime = 2f;
    public float fireRate = 15f;
    private bool isReloading = false;

    private float nextTimeToFire = 0f;
    public float damage = 70;
    public float range = 400f;
    public float impactForce = 30f;

    private void Start()
    {
        //currentAmmo = 30;        
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
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            muzzleFlash.Play();
            aa.Play();
            
        }
        if (currentAmmo <= 0 || (Input.GetKeyDown(KeyCode.R) && currentAmmo!=Maxammo)) 
        {
            //Play reload animation and input.GetButtonDown("Fire1")=locked and cant shoot
            StartCoroutine(Reload());
            return;
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime-0.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);
        isReloading = false;
        tempAmmo = 30-currentAmmo;
        currentAmmo = Maxammo;
        Totalammo = Maxammo - tempAmmo;
        
        ammotext.text = currentAmmo.ToString();
        TotalAmmo.text = TotalAmmo.ToString();
    }
    void Shoot()
    {
        currentAmmo--;
        ammotext.text = currentAmmo.ToString();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            //Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

        }
        //out hit stores the data that is gathered after the ray hits the object
    }
}
