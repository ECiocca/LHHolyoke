using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singular : SingletonBehavior<Singular> {


	private static Singular oneInstance;
	void Awake(){
		_CheckSingularity ();
	}


	void _CheckSingularity() {
		Debug.Log ("SING.AWAKE");

		if (oneInstance == null) {
			oneInstance = this;

			//			this.gameObject.transform.SetParent (null);
		

			DontDestroyOnLoad (this.gameObject);
			//we belong to nobody!.
			Debug.Log ("SING.DDD");
		} else {
			//wipe out any new ones.
			DestroyObject(this.gameObject);
			Debug.Log ("SING.TOOMANY");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
