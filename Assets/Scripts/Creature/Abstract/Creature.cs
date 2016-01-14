using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Creature : CreatureMethods 
{ 
	public override void Dead ()
	{
		base.Dead ();
		if (Hitpoints < 1) 
		{
			if (!Player) GameManager.crystal.Remove(this);
			if (Player) GameManager.castles.Remove (this);
			Destroy (this.gameObject);
		}
	}

	protected override void Start ()
	{
		CreatureType = "Creature";
		EnableState = true;
		if (!Player) GameManager.crystal.Add(this);
		if (Player) GameManager.castles.Add (this);
		if (Player) gameObject.AddComponent<Character_Controller>();
		ModifyLevel(1,1,1,1);	

		base.Start ();
	


	}
}