using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;
    public GameObject Gunend;
    public Camera view;

    public float speed = 1.0F;
    
    float x = 1;
    bool is_reloading = false;

    public AudioClip nuke;
    public AudioClip Reload;
    public AudioSource m_AudioSource;

    public Gun ThisGun;

    float Firerate = 0; //Needs to get pulled from gun class

    bool Scoped;

    public float Magnifucation;

    // Use this for initialization
    void Start () {
        ThisGun = this.gameObject.GetComponent<Gun>();
        

        Scoped = false;
        //Magnifucation = view.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Firerate > 0) {
            Firerate -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
            //don't do it if you are reloading
            if ((ThisGun.CurrentAmmo > 0)&&(!is_reloading))
            {
                if (Firerate <= 0)
                {
                    
                    GameObject go = GameObject.Instantiate(Bullet);
                    ThisGun.Shoot();
                    go.transform.position = Gunend.transform.position;
                    go.GetComponent<Rigidbody>().AddForce(Gunend.transform.forward * speed, ForceMode.Impulse);

                    m_AudioSource.clip = nuke;
                    m_AudioSource.Play();

                    Animator anm = GetComponent<Animator>();
                    if (anm != null)
                    {
                        anm.Play("Shoot");
                    }



                    Firerate = ThisGun.FireRate();
                    

                }
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R)&&(!is_reloading)) //If you press R
            {
                if (ThisGun.CurrentAmmo < ThisGun.MaxAmmo()) //If your clip isn't full
                {
                    x = ThisGun.RealoadingSpeed();
                    is_reloading = true;

                    Animator anm = GetComponent<Animator>();
                    if (anm != null)
                    {
                        anm.Play("Reload");
                    }

                    m_AudioSource.clip = Reload;
                    m_AudioSource.Play();


                }
            }
        }
        if (is_reloading) //If you aren't already reloading AND does counter for how long the reload is
        {
            x -= Time.deltaTime;
            Debug.Log(x);

            if (x <= 0)
            {
                //Change so theres an if statement here checking if you have the ammo
                ThisGun.CurrentAmmo = ThisGun.MaxAmmo();
                x = 1;
                is_reloading = false;

            }
        }


        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1))
        {
            Scoped = !Scoped;

            if (Scoped == true)
            {
                //Magnifucation = 15;
                view.fieldOfView = 15;
                
            }
            else
            {
                //Magnifucation = 60;
                view.fieldOfView = 60;
            }

            
        }

    }
    
}
