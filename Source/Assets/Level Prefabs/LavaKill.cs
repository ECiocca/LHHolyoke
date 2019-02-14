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
        Debug.Log("1");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("2");
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled=false;
            Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Camera.transform.position = DeathScrene.transform.position;
            Camera.transform.LookAt(Lookat.transform);
            GameObject.Destroy(HUD.gameObject);
            GameObject.Destroy(Body.gameObject);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
