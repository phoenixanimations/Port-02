using UnityEngine;
using System.Collections;

public class Cow : Creature
{

	protected override void Start ()
	{
		Health = 1;
		base.Start ();
	}

}
