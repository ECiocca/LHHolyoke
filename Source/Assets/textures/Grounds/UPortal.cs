using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPortal : MonoBehaviour {
    public float xspeed = 0F;
    public float yspeed = 0F;
    public float zspeed = 0F;
    public GameObject Spawnpoint;
    public GameObject Player;
    public GameObject Rotation;



        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
                NewMethod();
        }
        private void NewMethod()
        {
            //Chase go = GameObject.Instantiate(Player).GetComponent<Chase>();
            Player.transform.position = Spawnpoint.transform.position;
        Player.transform.LookAt(Rotation.transform);
        }

 
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(1, 0, 0), xspeed);
        transform.Rotate(new Vector3(0, 1, 0), yspeed);
        transform.Rotate(new Vector3(0, 0, 1), zspeed);


    }
}
