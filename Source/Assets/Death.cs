using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public GameObject Player;
    public Camera _camera;
    public GameObject Body;
    public GameObject HUD;
    public GameObject Lookat;
    public WeaponSwitcher weapons;

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


        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(1))
        {
            if (weapons.CurrentGun != null)
            {
                if (weapons.CurrentGun.CanScope())
                {
                    weapons.CurrentGun.DoScope(!weapons.CurrentGun.IsScoped());
                }

            }

        }

        //poll the current gun. Are we scoped?
        if (weapons.CurrentGun != null)
        {
            bool isScoped = weapons.CurrentGun.IsScoped();
            //adjust view based on scope
            if (isScoped == true)
            {
                _camera.fieldOfView = 15;
            }
            else
            {
                _camera.fieldOfView = 60;
            }
        }


    }

    public void KillPlayer()
    {
        CurrentHealth = 0;
        HCooldown = 10;
    }


    public void TakeDamage(float fDamage)
    {
        if (fDamage > 0)
        {
            CurrentHealth -= fDamage;
            HCooldown = 5;
        }
    }



}

