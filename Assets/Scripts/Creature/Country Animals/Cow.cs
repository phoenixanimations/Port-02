﻿using UnityEngine;
using System.Collections;

public class Cow : Creature
{
	protected override void Start ()
	{
		base.Start ();
		Health = 1;
	}

	public override void AI ()
	{
		base.AI ();
		gameObject.GetComponent<Creature>().MoveAttack(-transform.right);
	}
}