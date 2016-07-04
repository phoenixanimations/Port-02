using UnityEngine;
using System.Collections;

public class Raycast_Simple : Raycast_Stats 
{
	protected override void Start ()
	{
		base.Start ();
		Physics2D.queriesStartInColliders = false;
	}

	/********************************************
	 ********USING GIZMOS TO SEE YOUR ARRAY******
	 ********************************************/

	protected void DebugDrawRay (Vector2 Position, Vector2 Direction, float Length)
	{
		Debug.DrawRay(Position,Direction * Length,Color.red);
	}

	/********************************************
	 **************Position of Array*************
	 ********************************************/

	public Vector2 Position ()
	{
		return new Vector2 (transform.position.x + x, transform.position.y + y);
	}
}
