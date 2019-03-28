using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    public int weaponnumber = 0;

    public Gun[] Weapons;
       
	// Use this for initialization
	void Start () {
        SelectWeapon();
		
	}
	
	// Update is called once per frame
	void Update () {
        int lastselected = weaponnumber;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            

            if (weaponnumber >= Weapons.Length - 1)
                weaponnumber = 0;
            else
                weaponnumber++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weaponnumber <= 0)
                weaponnumber = Weapons.Length - 1;
            else
                weaponnumber--;
        }

       

        if (Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            weaponnumber = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponnumber = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            weaponnumber = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            weaponnumber = 3;
        }

        if (lastselected != weaponnumber)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon ()
    {
        int i = 0;
        foreach (Gun gun in Weapons )
        {
            if (i == weaponnumber)
                gun.gameObject.SetActive(true);

            else
                gun.gameObject.SetActive(false);


            i++;


        }
    }

}