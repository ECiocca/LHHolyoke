using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowbar : Gun {


    public GameObject Hitend;
    public GameObject Pain;
    public AudioClip nuke;
    public AudioSource m_AudioSource;

    void Start()
    {
        CurrentAmmo = MaxAmmo();

    }

    public override bool IsMelee() { return true; }


    // Update is called once per frame
    void Update()
    {

    }
    public override int Damage()
    {
        return 20;
    }
    public override int MaxAmmo()
    {
        return 0;
    }
    public override float FireRate()
    {
        return 1.0f;
    }
    public override int RealoadingSpeed()
    {
        return 0;
        //The higher number the longer it takes to reload
    }


    // Update is called once per frame
    void MakeThePain()
    {
        //make a pain object for one frame
        GameObject go = GameObject.Instantiate(Pain);
        go.transform.position = Hitend.transform.position;
        go.transform.forward = Hitend.transform.forward;
        go.transform.up = Hitend.transform.up;
        go.transform.parent = Hitend.transform;
        Melee me = go.GetComponent<Melee>();
        if (me!=null)
        {
            me.Damage = Damage();
        }
    }

    public override void Shoot()
    {
        Invoke("MakeThePain", 0.2F);

        m_AudioSource.clip = nuke;
        m_AudioSource.Play();

        Animator anm = GetComponent<Animator>();
        if (anm != null)
        {
            int indexcrowbar = Random.Range(1, 5);
            anm.Play("Swing" + indexcrowbar);
            Debug.Log("Swing" + indexcrowbar);
        }

    }


}
