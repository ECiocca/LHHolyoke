using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle1 : Gun
{


    public GameObject Bullet;
    public GameObject Gunend;
    public AudioClip loop;
    public AudioClip loopend;
    public AudioClip Reload;
    public AudioSource m_AudioSource;

    // Use this for initialization
    void Start()
    {
        CurrentAmmo = MaxAmmo();

    }

    public override bool IsAuto() { return true; }


    // Update is called once per frame
    void Update()
    {

    }
    public override int Damage()
    {
        return 2;
    }
    public override int MaxAmmo()
    {
        return 20;
    }
    public override float FireRate()
    {
        return 1f;
    }
    public override int RealoadingSpeed()
    {
        return 2;
        //The higher number the longer it takes to reload
    }

    bool isScoped = false;

    public override bool CanScope()
    {
        return true;
    }

    public override bool IsScoped()
    {
        return isScoped;
    }

    public override void DoScope(bool bDoScope)
    {
        isScoped = bDoScope;
    }

    public override void Shoot()
    {
        CurrentAmmo -= 1;

        GameObject go = GameObject.Instantiate(Bullet);

        go.transform.position = Gunend.transform.position;
        go.GetComponent<Rigidbody>().AddForce(Gunend.transform.forward * speed, ForceMode.Impulse);

        Bullet bu = go.GetComponent<Bullet>();
        if (bu != null)
        {
            bu.Damage = Damage();
        }

        m_AudioSource.clip = loop;
        m_AudioSource.loop = true;
        m_AudioSource.Play();

        Animator anm = GetComponent<Animator>();
        if (anm != null)
        {
            anm.Play("Shoot");
        }
    }

    public override void EndShoot()
    {

        m_AudioSource.loop = false;

        if (loopend != null)
        {
            m_AudioSource.clip = loopend;
            m_AudioSource.Play();
        }

    }

    public override void DoReload()
    {
        Animator anm = GetComponent<Animator>();
        if (anm != null)
        {
            anm.Play("Reload");
        }

        m_AudioSource.clip = Reload;
        m_AudioSource.loop = false;

        m_AudioSource.Play();
    }

}

