using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    float reload_time = 0.0F;
    bool is_reloading = false;

    bool did_fire = false;

    float Firerate = 0; //Needs to get pulled from gun class

   

    // Use this for initialization
    void Start () {

        //Magnifucation = view.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {

        Gun ThisGun = WeaponSwitcher.Instance.CurrentGun;

        if (Firerate > 0) {
            Firerate -= Time.deltaTime;
        }

        bool bAuto = ThisGun.IsAuto();
        bool bShoot = false;

        if (bAuto)
        {
            bShoot = (Input.GetKey(KeyCode.G) || Input.GetMouseButton(0));
        }
        else
        {
            bShoot = (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0));
        }

        if (bShoot)
        {
            //don't do it if you are reloading
            if ((ThisGun.CurrentAmmo > 0 || ThisGun.IsMelee()) && (!is_reloading) && (Firerate <= 0))
            {
                did_fire = true;
                ThisGun.Shoot();
                Firerate = ThisGun.FireRate();

            }

        }
        else
        {
            if (did_fire)
            {
                ThisGun.EndShoot();
                did_fire = false;
            }
            if (Input.GetKeyDown(KeyCode.R)&&(!is_reloading)) //If you press R
            {
                if (ThisGun.CurrentAmmo < ThisGun.MaxAmmo()) //If your clip isn't full
                {
                    ThisGun.DoReload();
                    reload_time = ThisGun.RealoadingSpeed();
                    is_reloading = true;

                }
            }
        }
        if (is_reloading) //If you aren't already reloading AND does counter for how long the reload is
        {
            reload_time -= Time.deltaTime;

            if (reload_time <= 0)
            {
                ThisGun.ReloadEnd();
                reload_time = 0;
                is_reloading = false;

            }
        }




    }
    
}
