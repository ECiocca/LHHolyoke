using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float lifespan = 2.0F;
    public float Damage = 20;
    public AudioClip nuke;
    public AudioSource soundPlayer;

    public bool bEnemyProjectile = false;

	// Use this for initialization
	void Start () {
        Invoke("Destroy",lifespan);
        if (soundPlayer != null)
        {
            soundPlayer.clip = nuke;
            soundPlayer.Play();
        }


    }

    // Update is called once per frame
    void Destroy()
    {
        GameObject.Destroy(this.gameObject);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        BulletKills bk = collision.gameObject.GetComponentInParent<BulletKills>();
        Death de = collision.gameObject.GetComponentInParent<Death>();

        if (!bEnemyProjectile && bk != null)
        {
            bk.TakeDamage(Damage);
            Destroy();
        }
        else if (bEnemyProjectile && de != null)
        {
            de.TakeDamage(Damage);
            Destroy();
        }
        else if (!(collision.gameObject.tag == "Player"))
        {
            Destroy();
        }
    }
    void Update () {

		
	}
}
