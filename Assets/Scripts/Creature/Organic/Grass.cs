using UnityEngine;
using System.Collections;

public class Grass : Creature {
	protected override void Start ()
	{
		base.Start ();
		Health = 1;
	}
}
