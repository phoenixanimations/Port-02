using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class List_Test : MonoBehaviour {
	int[] hi = {1,2,3};
	List<int> damnit = new List<int>();


	// Use this for initialization
	void Start () {

	damnit.Add(1);
//	damnit.Add(2);
//	damnit.Add(99);
//	damnit.Add(4);
	}
	
	// Update is called once per frame
	void Update () {
//	damnit.Remove(4);
	List<int> damnit = new List<int>(hi);

	for (int i = 0; i < damnit.Count; i++)
	Debug.Log (damnit[i]);
	}
}
