using UnityEngine;
using System.Collections;

public class Grass : Creature {
	protected override void Start ()
	{
		base.Start ();
		Hitpoints = 1;
	}
}
