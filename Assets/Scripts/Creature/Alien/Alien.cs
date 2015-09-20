using UnityEngine;
using System.Collections;

public class Alien : Creature
{

	protected override void Start ()
	{
		base.Start();
		Health = 10;
	}

	protected override void Update ()
	{	
		base.Update ();
	}

}
