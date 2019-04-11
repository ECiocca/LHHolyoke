using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour {
    public float lifespan = 2.0F;
    public float Damage = 20;

    List<BulletKills> _damagedGuys = new List<BulletKills>();

	// Use this for initialization
	void Start () {
        Invoke("Destroy",lifespan);
        Debug.Log("MAKE THE PAIN");
    }

    // Update is called once per frame
    void Destroy()
    {
        GameObject.Destroy(this.gameObject);
        Debug.Log("PAIN GONE");
    }

    private void OnTriggerEnter(Collider collision)
    {
        BulletKills bk = collision.gameObject.GetComponentInParent<BulletKills>();
        if (bk!=null)
        {
            Debug.Log("Hit!");
            if (!_damagedGuys.Contains(bk))
            {
                _damagedGuys.Add(bk);
                bk.health -= Damage;
                Debug.Log("Whack!");
//                Destroy();
            }
        }
    }


    void Update () {

		
	}
}
