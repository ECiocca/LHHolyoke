using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {
    public Transform target;
    public float speed = 1.0f;
    public float huntdistance = 30.0f;
    public float distance;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {


        //if we don't have any target set, try to get one
        if (target == null)
        {
            target = UnityStandardAssets.Characters.FirstPerson.FirstPersonController.Instance.gameObject.transform;
        }

        //only chase if we have a target
        if (target != null)
        {
            distance = (this.transform.position - target.position).magnitude;

            if (distance <= huntdistance)
            {
                transform.LookAt(target);
                transform.localPosition += transform.forward * Time.deltaTime * speed;
            }
        }
    }
}
