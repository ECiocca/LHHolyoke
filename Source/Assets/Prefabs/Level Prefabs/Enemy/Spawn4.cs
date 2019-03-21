using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn4 : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;
    public GameObject Target;

    float Count;

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
            Chase go = GameObject.Instantiate(Enemy).GetComponent<Chase>();
            go.transform.position = SpawnPoint1.transform.position;
            go.target = Target.transform;
            Chase go2 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
            go2.transform.position = SpawnPoint2.transform.position;
            go2.target = Target.transform;
            Chase go3 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
            go3.transform.position = SpawnPoint3.transform.position;
            go3.target = Target.transform;
            Chase go4 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
            go4.transform.position = SpawnPoint4.transform.position;
            go4.target = Target.transform;
            Count += 1;
        }
    }



        // Update is called once per frame
        void Update()
        {
        }
    }


