using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Mouse_Controller : MonoBehaviour 
{
	public GameObject Menu;
	public GameObject Move_Select;

	
	public void Start ()
	{
		this.gameObject.AddComponent<BoxCollider2D>();
	}
	
	public void OnMouseDown()
	{
		
//		float x = transform.position.x;
//		float y = transform.position.y;
//		Move_Select.transform.position = new Vector3(x + Vector.Up.x,y + Vector.Up.y,0f);
		GameObject test = Instantiate(Menu);
//		test.transform.position = new Vector3 (transform.position.x + Vector.Up.x,transform.position.y + Vector.Up.y);
//		test.gameObject.AddComponent<BoxCollider2D>();
//		test.transform.position = Vector3.
//		Debug.Log(test.transform.position);
//		test.layer = 
		test.transform.parent = this.transform;
		
	}	
}