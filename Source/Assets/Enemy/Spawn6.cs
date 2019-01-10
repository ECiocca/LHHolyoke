using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn6 : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;
    public GameObject SpawnPoint5;
    public GameObject SpawnPoint6;
    public GameObject Target;
    public float Count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            NewMethod();
    }
    private void NewMethod()
    {
        Count += 1;

        if (Count.Equals(1))
        {
            Debug.Log("TOUCHING");
            if (SpawnPoint1 != null)
            {
                Chase go = GameObject.Instantiate(Enemy).GetComponent<Chase>();
                go.transform.localPosition = Vector3.zero;
                go.transform.position = SpawnPoint1.transform.position;
                go.target = Target.transform;
            }
            if (SpawnPoint2 != null)
            {
                Chase go2 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
                go2.transform.localPosition = Vector3.zero;
                go2.transform.position = SpawnPoint2.transform.position;
                go2.target = Target.transform;
            }
            if (SpawnPoint3 != null)
            {
                Chase go3 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
                go3.transform.localPosition = Vector3.zero;
                go3.transform.position = SpawnPoint3.transform.position;
                go3.target = Target.transform;
            }
            if (SpawnPoint4 != null)
            {
                Chase go4 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
                go4.transform.localPosition = Vector3.zero;
                go4.transform.position = SpawnPoint4.transform.position;
                go4.target = Target.transform;
            }
            if (SpawnPoint5 != null)
            {
                Chase go5 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
                go5.transform.localPosition = Vector3.zero;
                go5.transform.position = SpawnPoint5.transform.position;
                go5.target = Target.transform;
            }
            if (SpawnPoint6 != null)
            {
                Chase go6 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
                go6.transform.localPosition = Vector3.zero;
                go6.transform.position = SpawnPoint6.transform.position;
                go6.target = Target.transform;
            }
            Count += 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}

