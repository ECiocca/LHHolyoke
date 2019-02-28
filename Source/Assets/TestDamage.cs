using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour
{
    public float speed = 1f;
    public float Damage = 50f;

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        GameObject.Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.Cross(this.transform.up, this.transform.forward) * speed, ForceMode.Impulse);

    }
}
