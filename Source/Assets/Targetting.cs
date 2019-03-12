using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetting : MonoBehaviour {
    public Transform target;
    public float movement = 1f;
    public Chase Player;

	// Use this for initialization
	void Start () {
        target = Player.target;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v3dif = target.transform.position - this.transform.position;

        v3dif.Normalize();
        GetComponent<Rigidbody>().AddForce(v3dif * movement);

    }
}
