using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject Bullet;
    public GameObject Gunend;

    public float speed = 1.0F;
    
    float x = 1;
    bool r = false;

    public AudioClip nuke;
    public AudioSource m_AudioSource;

    public Gun ThisGun;


    // Use this for initialization
    void Start () {
        ThisGun = this.gameObject.GetComponent<Gun>();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
            if (ThisGun.CurrentAmmo > 0)
            {
                GameObject go = GameObject.Instantiate(Bullet);
                ThisGun.Shoot();
                go.transform.position = Gunend.transform.position;
                go.GetComponent<Rigidbody>().AddForce(Vector3.Cross(this.transform.up, this.transform.forward) * speed, ForceMode.Impulse);

                m_AudioSource.clip = nuke;
                m_AudioSource.Play();

            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R)) //If you press R
            {
                if (ThisGun.CurrentAmmo < ThisGun.MaxAmmo()) //If your clip isn't full
                {
                    x = ThisGun.RealoadingSpeed();
                    r = true;
                }
            }
        }
        if (r) //If you aren't already reloading AND does counter for how long the reload is
        {
            x -= Time.deltaTime;
            Debug.Log(x);
        }
        if (x <= 0)
        {
            //Change so theres an if statement here checking if you have the ammo
            ThisGun.CurrentAmmo = ThisGun.MaxAmmo();
            x = 1;
            r = false;
        }

    }
    
}
