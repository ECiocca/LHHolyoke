using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U))
        {
            MusicController.Instance.PlayTrack("title");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            MusicController.Instance.PlayTrack("levela");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            MusicController.Instance.PlayTrack("levelb");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            MusicController.Instance.PlayTrack("levelc");
        }
    }
}
