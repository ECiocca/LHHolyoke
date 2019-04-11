using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour {

    bool Third = false;

    float x = -1;
    float y = 1;
    float z = -4;

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.V))
            {
            Third = !Third;
            if (Third)
                this.transform.localPosition += new Vector3(x, y, z);
            else
            {
                this.transform.localPosition += new Vector3(-x, -y, -z);
            }


        }


    }
}
