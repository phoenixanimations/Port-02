using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Raycast : BasicTile 
{
	public float x {get; private set;}
	public float y {get; private set;}
	protected RaycastHit2D Hit;
	protected RaycastHit2D[] HitArray;
	
	protected void Raycast_Stats ()
	{
		if (GetComponent(typeof(SpriteRenderer)) != null)
		{
			x = GetComponent<SpriteRenderer> ().bounds.size.x;
			y = GetComponent<SpriteRenderer> ().bounds.size.y;
		}
		
		Physics2D.queriesStartInColliders = false;
	}

}