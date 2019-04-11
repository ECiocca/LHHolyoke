using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle1 : Gun
{

    // Use this for initialization
    void Start()
    {
        CurrentAmmo = MaxAmmo();

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override int Damage()
    {
        return 2;
    }
    public override int MaxAmmo()
    {
        return 20;
    }
    public override float FireRate()
    {
        return 1f;
    }
    public override int RealoadingSpeed()
    {
        return 2;
        //The higher number the longer it takes to reload
    }

    bool isScoped = false;

    public override bool CanScope()
    {
        return true;
    }

    public override bool IsScoped()
    {
        return isScoped;
    }

    public override void DoScope(bool bDoScope)
    {
        isScoped = bDoScope;
    }

}

