using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shoot2 : MonoBehaviour
{
 
    public GameObject Bullet;
    public GameObject Gunend;
 
    public float speed = 1.0F;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
 
    float x = 1;
    bool r = false;
 
    public AudioClip loop;
    public AudioClip loopend;
    public AudioClip Reload;
    public AudioSource m_AudioSource;
 
    public Gun ThisGun;
 
 
    // Use this for initialization
    void Start()
    {
        ThisGun = this.gameObject.GetComponent<Gun>();
    }
 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G) || Input.GetMouseButton(0) && Time.time > nextFire)
        {
            if (ThisGun.CurrentAmmo > 0)
            {
               
                GameObject go = GameObject.Instantiate(Bullet);
                ThisGun.Shoot();
                go.transform.position = Gunend.transform.position;
                go.GetComponent<Rigidbody>().AddForce(Gunend.transform.forward * speed, ForceMode.Impulse);
                nextFire = Time.time + fireRate;
           
                m_AudioSource.clip = loop;
                m_AudioSource.loop = false;
         
 
 
                Animator anm = GetComponent<Animator>();
                if (anm != null)
                {
                    anm.Play("Shoot");
                    nextFire = Time.time + fireRate;
                   
                }
 
                m_AudioSource.Play();
 
            }
 
            else
            {
             //   m_AudioSource.Play();
             //   m_AudioSource.clip = loopend;
            //    m_AudioSource.loop = false;
               
            }
 
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R)) //If you press R
            {
                if (ThisGun.CurrentAmmo < ThisGun.MaxAmmo()) //If your clip isn't full
                {
 
                    Animator anm = GetComponent<Animator>();
                    if (anm != null)
                    {
                        anm.Play("Reload");
                    }
 
                    x = ThisGun.RealoadingSpeed();
                    r = true;
                    m_AudioSource.clip = Reload;
                    m_AudioSource.loop = false;
                    m_AudioSource.Play();
                }
            }
        }
        if (r) //If you aren't already reloading AND does counter for how long the reload is
        {
            x -= Time.deltaTime;
            Debug.Log(x);
        }
        if (x <= 0)
        {
            //Change so theres an if statement here checking if you have the ammo
            ThisGun.CurrentAmmo = ThisGun.MaxAmmo();
            x = 1;
            r = false;
        }
 
    }
 
}