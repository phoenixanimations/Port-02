using UnityEngine;
using System.Collections;

public class RaycastTest : MonoBehaviour {
	RaycastHit2D Test;
	// Use this for initialization
	void Start () {
		Physics2D.queriesStartInColliders = false;
		Test = Physics2D.Raycast(transform.position,(-transform.right + transform.up),1f);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(Test.collider);
	}
}
