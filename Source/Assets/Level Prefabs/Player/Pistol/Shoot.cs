using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;
    public GameObject Gunend;
    public GameObject Devil;
    public GameObject SpawnPoint;

    public float speed = 1.0F;
    public float Xrot = 0F;
    public float Yrot = 90F;
    public float Zrot = 0F;
    public AudioClip nuke;
    public AudioSource m_AudioSource;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
            GameObject go = GameObject.Instantiate(Bullet);
            //go.transform.position = this.transform.position + (transform.up*up);
            //go.GetComponent<Rigidbody>().AddForce(Quaternion.Euler(Xrot,Yrot,Zrot)*this.transform.forward*speed, ForceMode.Impulse);
            go.transform.position = Gunend.transform.position;
            go.transform.position = Gunend.transform.position;
            go.GetComponent<Rigidbody>().AddForce(Vector3.Cross(this.transform.up, this.transform.forward) * speed, ForceMode.Impulse);

            Animator Shoot = GetComponent<Animator>();
            if (Shoot != null)
            {
                Shoot.Play("Shoot");
            }

            m_AudioSource.clip = nuke;
            m_AudioSource.Play();


        }


    }
}
