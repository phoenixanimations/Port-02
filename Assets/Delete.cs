using UnityEngine;
using System.Collections;

public class Delete : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		string url = "http://www.phoenixanimations.com/_server/PHP/stresstest/getstress.php"; //hope.php || tristans_ugh.php
		WWW www = new WWW(url);
		yield return www;
		// 
		//         // check for errors
		if (www.error == null)
		{
			Debug.Log("Done: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
