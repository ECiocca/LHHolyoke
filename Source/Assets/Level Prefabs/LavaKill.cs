using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaKill : MonoBehaviour {
    public GameObject DeathScrene;
    public GameObject Body;
    public GameObject Lookat;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("1");
        if (collision.gameObject.tag == "Respawn")
            Debug.Log("2");
            respawn();
    }

    private void respawn()
    {
        Debug.Log("3");
        this.transform.position = DeathScrene.transform.position;
        GameObject.Destroy(Body.gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
