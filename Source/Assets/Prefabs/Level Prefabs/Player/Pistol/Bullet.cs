﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifespan = 2.0F;
    public float Damage = 20;
    public AudioClip nuke;
    public AudioSource soundPlayer;

	// Use this for initialization
	void Start () {
        Invoke("Destroy",lifespan);
        if (soundPlayer != null)
        {
            soundPlayer.clip = nuke;
            soundPlayer.Play();
        }


    }

    // Update is called once per frame
    void Destroy()
    {
        GameObject.Destroy(this.gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletKills bk = collision.gameObject.GetComponentInParent<BulletKills>();
        if (bk != null)
        {
            Debug.Log("Hit!");
            bk.health -= Damage;
            Destroy();
        }
        else if (!(collision.gameObject.tag == "Player"))
        {
            Destroy();
        }
    }
    void Update () {

		
	}
}
