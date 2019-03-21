using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour {
    public Transform target;
    public float armspeed= 100;
    public GameObject Snowball;
    public GameObject Spawnpoint;
    

    public float height = 10.0F;
    public float horizantal;
    public float vertical;
    public float speed = 1;

    float distance;
    float time;
    float timer;
    float wait;

    private void Start()
    {
        wait = Random.Range(0.5f, 8.0f);
        target = UnityStandardAssets.Characters.FirstPerson.FirstPersonController.Instance.gameObject.transform;

        time = 175/armspeed;
    }
 

    // Update is called once per frame
    void Update ()
    {
        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }
        else
        {
            Vector3 direction = target.position - this.transform.position;
            direction.y = 0;
            direction.Normalize();

            distance = (this.transform.position - target.position).magnitude;
            horizantal = distance / 1.7f;
            vertical = distance / 6f;

            transform.Rotate(new Vector3(1, 0, 0), armspeed * Time.deltaTime);
            timer += Time.deltaTime;




            if (timer >= time)

            {
                GameObject go = GameObject.Instantiate(Snowball);
                go.transform.position = Spawnpoint.transform.position;
                Targetting myTarget = go.GetComponent<Targetting>();
                if (myTarget != null)
                {
                    myTarget.target = target;
                }
                go.GetComponent<Rigidbody>().AddForce(direction * horizantal + new Vector3(0, 1, 0) * vertical, ForceMode.Impulse);


                timer = -time;


            }
        }
    }
}
