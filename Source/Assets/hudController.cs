using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudController : MonoBehaviour {
    public Text AmmoNum;
    public WeaponSwitcher weapons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (weapons.CurrentGun != null)
        {
            AmmoNum.text = weapons.CurrentGun.CurrentAmmo.ToString();
        }
		
	}
}
