using UnityEngine;
using System.Collections;

public class YESITLIVES : MonoBehaviour {

	public  string hi = "default";
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Invoke("Move",3f);
		//Debug.Log ("IT LIVES");

	}
	void move () 
	{
		gameObject.GetComponent<Alien>().Move ("Left");
	}
}
