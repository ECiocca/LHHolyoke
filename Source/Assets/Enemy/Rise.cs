﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rise : MonoBehaviour {
    public Transform target;
    public float speed = 1.0f;
    public float distance;
    public float Risespeed;
    public float Maxy;
    public float Rose;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per fram
	void Update () {



        if (this.transform.position.y <= Maxy)
            if (Rose == 0)
            {
                {
                    this.transform.position += new Vector3(0, Risespeed, 0);
                    if (this.transform.position.y >= Maxy)
                        Rose = 1;
                    Debug.Log("RISING");
                }
            }
        distance = (this.transform.position - target.position).magnitude;
        
            if (Rose == 1)
            {
                transform.LookAt(target);
                transform.localPosition += transform.forward * Time.deltaTime * speed;
            }
        

    }
}
