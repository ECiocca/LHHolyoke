using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour {
    public GameObject Light;
    float Timer = 10;
    bool Switch;


	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {

        Timer += Time.deltaTime;
        if (Timer >= 1) { 
        Light.SetActive(!Light.activeSelf);      
        Timer = 0;
            }
       

	}
}
