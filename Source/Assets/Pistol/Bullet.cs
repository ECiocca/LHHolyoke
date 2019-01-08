using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifespan = 2.0F;

	// Use this for initialization
	void Start () {
        Invoke("Destroy",lifespan);
		
	}

    // Update is called once per frame
    void Destroy()
    {
        GameObject.Destroy(this.gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.tag == "Player"))
        {
            Destroy();
        }
    }
    void Update () {

		
	}
}
