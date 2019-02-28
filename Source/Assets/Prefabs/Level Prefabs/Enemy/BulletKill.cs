using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKill : MonoBehaviour {
    public float health;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
                GameObject.Destroy(this.gameObject);
        }
        }


    

    // Update is called once per frame
    void Update() {
    }
}
