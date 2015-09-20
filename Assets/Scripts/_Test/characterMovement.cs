using UnityEngine;
using System.Collections;

public class characterMovement : MonoBehaviour {

//	private float x = 0f;
//	private float y = 0f;
//	private bool stop = false;
	//testvariabletransfer;
	void Start () {
	//hi = GetComponent("testvariabletransfer");
	//Debug.Log (hi.yay);
	}

	void Update () {

		Movement();
		//stop = false;

	}

	private void Movement () 
	{


		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			transform.position += new Vector3(0,-.5f,0);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			transform.position += new Vector3(0,.5f,0);	
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (leftGo)
			transform.position += new Vector3(-.5f,0,0);	
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			transform.position += new Vector3(.5f,0,0);
		}

		leftGo = true;
	}
	private bool leftGo = false;

	public void Stop () {
		leftGo = false;
		//x = 0f;
		//y = 0f;
		//stop = true; 

	}

}
