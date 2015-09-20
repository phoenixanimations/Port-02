using UnityEngine;
using System.Collections;

public class Status : Movement {
	protected RaycastHit2D Hit;
	protected override void Start () 
	{
		Physics2D.raycastsStartInColliders = false;
		//this.GetComponent<Creature>().
	}
	protected void HitDirection (string Direction, float Distance)
	{
		switch (Direction)
		{
			case "Left":
				Hit = Physics2D.Raycast(transform.position,-transform.right,x * Distance);
			break;
			case "Right":
				Hit = Physics2D.Raycast(transform.position,transform.right,x * Distance);
			break;
			case "Down":
				Hit = Physics2D.Raycast(transform.position,-transform.up,x * Distance);
			break;
			case "Up":
				Hit = Physics2D.Raycast(transform.position,transform.up,x * Distance);
			break;
		}
	}
	public virtual void Activate ()
	{
		Debug.Log ("Activated");
	}

}
