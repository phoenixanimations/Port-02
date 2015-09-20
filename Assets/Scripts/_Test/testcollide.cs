using UnityEngine;
using System.Collections;

public class testcollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Rigidbody2D.isKinematic)
	//	Debug.Log ("YAYA");

	
	}

	//public bool characterInQuicksand;
	void OnTriggerStay2D(Collider2D other) {
		//Debug.Log (other);
	}
}
