using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour{

    public GameObject Player;
    public GameObject Camera;
    public GameObject Body;
    public GameObject DeathScrene;
    public GameObject HUD;
    public GameObject Lookat;
    public Shoot Zoom;

    public GameObject deathUI;


    public float CurrentHealth = 100f;
    public float HCooldown;

    private void Start()
    {
        deathUI.SetActive(false);
        Health myHealth = this.gameObject.GetComponent<Health>();
        CurrentHealth = myHealth.StartHealth;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CurrentHealth = 0;
            HCooldown = 10;
        }

        if (CurrentHealth <= 0)
        {
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //Camera.transform.position = DeathScrene.transform.position;
            //Camera.transform.LookAt(Lookat.transform);
            Zoom.Magnifucation = 15;
            //if (HUD != null)
            //{
            //    HUD.gameObject.SetActive(false);
            //}
            GameObject.Destroy(Body.gameObject);

            if (deathUI != null)
            {
                deathUI.SetActive(true);
            }

            Cursor.lockState = CursorLockMode.None;


        }
    }

    public void KillPlayer()
    {
        CurrentHealth = 0;
        HCooldown = 10;
    }



    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Damage")
        {
            Bullet TheBullet = other.gameObject.GetComponent<Bullet>();
            Health myHealth = this.gameObject.GetComponent<Health>();


            if (TheBullet != null)
            {
                CurrentHealth -= TheBullet.Damage;

                HCooldown = 5;
                
            }
        }

       
    }
    }

