using UnityEngine;
using System.Collections;

public class testingEmunators : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (i == 10) return;
	Debug.Log("START");
		StartCoroutine(test ());
	Debug.Log("END");




	}

	int i = 0;
	IEnumerator test ()
	{
		while(i < 10)
		{
			i++;
			Debug.Log(i);
			yield return new WaitForSeconds(0);
		}
	}



}
