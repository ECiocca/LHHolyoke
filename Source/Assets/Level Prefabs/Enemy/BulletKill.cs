using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKill : MonoBehaviour {
    public float health;
    public float Count;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Count += 1;

            if (Count.Equals(health))
                GameObject.Destroy(this.gameObject);
           
            }
        }


    

    // Update is called once per frame
    void Update() {
    }
}
