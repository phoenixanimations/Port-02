using UnityEngine;
using System.Collections;

public class MoveRight : MonoBehaviour {
	private bool turnOn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (this.GetComponent<Creature>().Turn);
		if (this.GetComponent<Creature>().Turn)
		gameObject.GetComponent<Movement>().Move ("Right");
	}


}
