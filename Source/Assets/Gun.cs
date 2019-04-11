﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public int CurrentAmmo;
    public void Shoot() {
        CurrentAmmo -= 1;
            }



    public virtual bool CanScope()
    {
        return false;
    }

    public virtual bool IsScoped()
    {
        return false;
    }

    public virtual void DoScope(bool bDoScope)
    {
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public virtual int Damage()
    {
        return 0;
    }
    public virtual int MaxAmmo()
    {
        return 0;
    }
    public virtual float FireRate()
    {
        return 1;
    }
    public virtual int RealoadingSpeed()
    {
        return 1;
    }
    
}
