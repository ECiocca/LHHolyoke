using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HART
{

    public class DontDestroyOnLoad : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
