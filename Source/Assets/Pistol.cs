using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {


    public GameObject Bullet;
    public GameObject Gunend;
    public AudioClip nuke;
    public AudioClip Reload;
    public AudioSource m_AudioSource;


    // Use this for initialization
    void Start ()
    {
        CurrentAmmo = MaxAmmo();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public override int Damage()
    {
        return 1;
    }
    public override int MaxAmmo()
    {
        return 8;
    }
    public override float FireRate()
    {
        return 0.2f;
    }

    public override int RealoadingSpeed()
    {
        return 2;
        //The higher number the longer it takes to reload
    }
    public override void Shoot()
    {
        CurrentAmmo -= 1;

        GameObject go = GameObject.Instantiate(Bullet);

        go.transform.position = Gunend.transform.position;
        go.GetComponent<Rigidbody>().AddForce(Gunend.transform.forward * speed, ForceMode.Impulse);

        Bullet bu = go.GetComponent<Bullet>();
        if (bu!=null)
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
        Animator anm = GetComponent<Animator>();
        if (anm != null)
        {
            anm.Play("Reload");
        }

        m_AudioSource.clip = Reload;
        m_AudioSource.Play();
    }
}
