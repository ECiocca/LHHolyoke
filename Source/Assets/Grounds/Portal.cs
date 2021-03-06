﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
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
            //Player.transform.LookAt(Rotation.transform);
            Player.transform.Rotate(new Vector3(0, 180, 0));

    }


    private void Start()
    {
        if (Player==null)
        {
            Player = UnityStandardAssets.Characters.FirstPerson.FirstPersonController.Instance.gameObject;
        }
    }


    // Update is called once per frame
    void Update () {
        transform.Rotate(new Vector3(1, 0, 0), xspeed *Time.deltaTime);
        transform.Rotate(new Vector3(0, 1, 0), yspeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, 1), zspeed * Time.deltaTime);


    }
}
