using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {

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
        return 12;
    }
    public override int FireRate()
    {
        return 1;
    }
    public override int RealoadingSpeed()
    {
        return 4;
        //The higher number the longer it takes to reload
    }

}
