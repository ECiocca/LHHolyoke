using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
    public Bullet Fire;
    public GameObject Mouth;

    public float speed = 10;
    float Firerate = 1;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Firerate > 0)
            Firerate -= Time.deltaTime;
        if (Firerate <= 0)
        {
            GameObject go = GameObject.Instantiate(Fire.gameObject);
            go.transform.position = Mouth.transform.position;
            go.GetComponent<Rigidbody>().AddForce(Mouth.transform.forward * speed, ForceMode.Impulse);

            Firerate = 1.5f;

        }
    }
}
