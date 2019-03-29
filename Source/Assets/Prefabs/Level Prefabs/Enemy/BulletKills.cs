using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKills : MonoBehaviour {
    public AudioClip hitMarker;
    public AudioSource a_AudioSource;
    public Transform Player;


    public float health = 5f;

    public float damage = 1f;

    // Use this for initialization

    private void Start()
    {
       a_AudioSource = UnityStandardAssets.Characters.FirstPerson.FirstPersonController.Instance.gameObject.transform.Find("NewObject").GetComponent<AudioSource>();
    }
    public void TakeDamage()
    {
        a_AudioSource.clip = hitMarker;
        a_AudioSource.Play();
               
        health -= damage;
        Debug.Log(health);
            
                if (health <= 0)
                {
                    GameObject.Destroy(this.gameObject);
                }
            
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDamage();
        }
        else
        {
        }
    }


    

    // Update is called once per frame
    void Update() {
        
        }
    }

