using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && plane.transform.position.x - this.transform.position.x <= 100 && plane.transform.position.y - this.transform.position.y <= 100 && plane.transform.position.z - this.transform.position.z <= 100 && transform.parent != plane.transform)
        {
            gameObject.transform.parent = plane.gameObject.transform;
            gameObject.transform.localPosition = new Vector3(0, 110, 300);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.E) && plane.transform.position.x - this.transform.position.x <= 4 && plane.transform.position.y - this.transform.position.y <= 4 && plane.transform.position.z - this.transform.position.z <= 4 && transform.parent == plane.transform)
        {
            gameObject.transform.parent = null;
            gameObject.transform.localPosition = new Vector3(80, 300, 85);
            gameObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}