using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaKill : MonoBehaviour {
    public GameObject DeathScrene;
    public GameObject Body;
    public GameObject Player;
    public GameObject Camera;
    public GameObject Lookat;
    public GameObject HUD;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Death de = collision.gameObject.GetComponentInParent<Death>();
            if (de!=null)
            {
                de.KillPlayer();
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
