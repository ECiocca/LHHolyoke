using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hudController : MonoBehaviour {
    public Text AmmoNum;
    public Shoot ThisAmmo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        AmmoNum.text = ThisAmmo.ThisGun.CurrentAmmo.ToString();
		
	}
}
