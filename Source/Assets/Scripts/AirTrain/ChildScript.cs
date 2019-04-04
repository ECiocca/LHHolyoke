using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : MonoBehaviour
{
    public GameObject plane;
    bool isAirplaneChild = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && plane.transform.position.x - this.transform.position.x <= 100 && plane.transform.position.y - this.transform.position.y <= 100 && plane.transform.position.z - this.transform.position.z <= 100 && transform.parent != plane.transform)
        {
            transform.parent = plane.gameObject.transform;
            transform.localPosition = new Vector3(0, 110, 300);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            isAirplaneChild = true;
        }

        if (Input.GetKeyUp(KeyCode.E) && isAirplaneChild == true)
        {
            transform.localPosition = new Vector3(80, 300, 85);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            isAirplaneChild = false;
        }
    }
}