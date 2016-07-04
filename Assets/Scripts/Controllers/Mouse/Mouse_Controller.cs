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
	}
	
	protected override void Update ()
	{
		base.Update ();
//		Debug.Log(Creature.Get_Stat(Stat.Movement));
//		Spawn_Diamond(Move_Select,Creature.Get_Stat(Stat.Movement));
	}

	public void OnMouseDown()
	{
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