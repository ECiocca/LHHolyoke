using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMELEE : MonoBehaviour
{

    public GameObject Hitend;
    public Camera view;
    public GameObject Pain;

    public float Damage = 1.0f;
    public float speed = 1.0F;

    float x = 1;

    public AudioClip nuke;
    public AudioSource m_AudioSource;

    public Gun ThisGun;

    float Firerate = 0; //Needs to get pulled from gun class

    bool Scoped;

    public int indexcrowbar;

    public float Magnifucation;

    // Use this for initialization
    void Start()
    {
        ThisGun = this.gameObject.GetComponent<Gun>();


        Scoped = false;
        //Magnifucation = view.fieldOfView;
    }

    // Update is called once per frame
    void MakeThePain()
    {
        //make a pain object for one frame
        GameObject go = GameObject.Instantiate(Pain);
        go.transform.position = Hitend.transform.position;
        go.transform.forward = Hitend.transform.forward;
        go.transform.up = Hitend.transform.up;
        go.transform.parent = Hitend.transform;
    }

    void Update()
    {


        if (Firerate > 0)
        {
            Firerate -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0))
        {
           

                if (Firerate <= 0)
                {
                    Invoke("MakeThePain", 0.2F);
                   
                    m_AudioSource.clip = nuke;
                    m_AudioSource.Play();

                    Animator anm = GetComponent<Animator>();
                    if (anm != null)
                    {
                        indexcrowbar = Random.Range(1, 5);
                        anm.Play("Swing"+ indexcrowbar);
                        Debug.Log("Swing" + indexcrowbar);
                        
                        
                    }



                    Firerate = ThisGun.FireRate();


                }
            

        }
 
    }


}