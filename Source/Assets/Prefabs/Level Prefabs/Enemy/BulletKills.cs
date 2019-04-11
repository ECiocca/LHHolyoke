using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKills : MonoBehaviour {
    public float health = 5f;

    public float damage = 1f;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.gameObject.tag == "Bullet")
        {
            health -= damage;
            {
                if (health <= 0)
                {
                    GameObject.Destroy(this.gameObject);
                }
            }
        }
        */
    }


    

    // Update is called once per frame
    void Update() {
        if (health <= 0)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
