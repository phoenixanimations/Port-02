using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Raycast : Stats 
{
	protected float x, y;
	protected RaycastHit2D Hit;
	protected RaycastHit2D[] HitArray;
	
	protected override void Start ()
	{
		base.Start ();
		x = GetComponent<SpriteRenderer> ().bounds.size.x;
		y = GetComponent<SpriteRenderer> ().bounds.size.y;
		Physics2D.queriesStartInColliders = false;
	}

}