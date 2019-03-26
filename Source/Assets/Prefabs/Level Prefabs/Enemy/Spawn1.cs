using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn1 : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject Target;
    public float Count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            trigger();
    }
    private void trigger()
    {
        Count += 1;

        if (Count.Equals(1))
        {
            Chase go = GameObject.Instantiate(Enemy).GetComponent<Chase>();
            go.transform.position = SpawnPoint1.transform.position;
            go.target = Target.transform;
            
            Chase go2 = GameObject.Instantiate(Enemy).GetComponent<Chase>();
            go2.transform.position = SpawnPoint2.transform.position;
            go2.target = Target.transform;
            Count += 1;
        }
    }

    // Update is called once per frame
    void Update() {
    }
}
    
