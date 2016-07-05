using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Mouse_Controller : Pathfinding 
{
	public GameObject Menu;
	public GameObject Move_Select;
	public Creature Creature;

	override protected void Start ()
	{
		base.Start ();
		Creature = GetComponent<Creature>();
		gameObject.AddComponent<BoxCollider2D>();

//		Move_Select.AddComponent<BoxCollider2D>();
//		Move_Select.AddComponent<Move_Select>();
	}

	public void OnMouseDown()
	{
		Spawn_Diamond(Move_Select,Creature.Get_Stat(Stat.Movement));
//		float x = transform.position.x;
//		float y = transform.position.y;
//		Move_Select.transform.position = new Vector3(x + Vector.Up.x,y + Vector.Up.y,0f);
//		GameObject test = Instantiate(Menu);
//		test.transform.position = new Vector3 (transform.position.x + Vector.Up.x,transform.position.y + Vector.Up.y);
//		test.gameObject.AddComponent<BoxCollider2D>();
//		Debug.Log(test.transform.position);
//		test.layer = 
//		test.transform.position = Vector3.
//		test.transform.parent = this.transform;
		
	}	
}