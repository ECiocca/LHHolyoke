using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{

    public GameObject Bullet;
    public GameObject Gunend;
    public AudioClip nuke;
    public AudioClip Reload;
    public AudioClip ReloadRepeat;
    public AudioClip ReloadFinish;


    bool is_reloading = false; 
    float reload_time = 0.0F;

    public AudioSource m_AudioSource;

    // Use this for initialization
    void Start()
    {
        CurrentAmmo = MaxAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if (is_reloading)
        {
            reload_time -= Time.deltaTime;
            if (reload_time <= 0.0F)
            {
                CurrentAmmo += 1;
                //shall we do another?
                if (CurrentAmmo < MaxAmmo())
                {
                    Animator anm = GetComponent<Animator>();
                    if (anm != null)
                    {
                        anm.Play("ReloadRepeat", -1, 0);
                        m_AudioSource.clip = ReloadRepeat;
                        m_AudioSource.Play();
                        reload_time = RealoadingSpeed();
                    }
                }
                else
                {
                    is_reloading = false;
                    Animator anm = GetComponent<Animator>();
                    if (anm != null)
                    {
                        anm.Play("ReloadEnd");
                    }
                    m_AudioSource.clip = ReloadFinish;
                    m_AudioSource.Play();
                }
            }
        }
    }
    public override int Damage()
    {
        return 1;
    }
    public override int MaxAmmo()
    {
        return 6;
    }
    public override float FireRate()
    {
        return 1.0f;
    }
    public override int RealoadingSpeed()
    {
        return 2;
        //The higher number the longer it takes to reload
    }


    public override void Shoot()
    {

        is_reloading = false;
        reload_time = 0.0F;

        CurrentAmmo -= 1;

        GameObject go = GameObject.Instantiate(Bullet);

        go.transform.position = Gunend.transform.position;
        go.GetComponent<Rigidbody>().AddForce(Gunend.transform.forward * speed, ForceMode.Impulse);

        Bullet bu = go.GetComponent<Bullet>();
        if (bu != null)
        {
            bu.Damage = Damage();
        }

        m_AudioSource.clip = nuke;
        m_AudioSource.Play();

        Animator anm = GetComponent<Animator>();
        if (anm != null)
        {
            anm.Play("Shoot");
        }

    }

    public override void DoReload()
    {
        is_reloading = true;

        reload_time = RealoadingSpeed();

        Animator anm = GetComponent<Animator>();
        if (anm != null)
        {
            anm.Play("Reload");
        }

        m_AudioSource.clip = Reload;
        m_AudioSource.Play();
    }

    public override void ReloadEnd()
    {
        //this is handled internally
    }

}
