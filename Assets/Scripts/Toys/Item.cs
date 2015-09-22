using UnityEngine;
using System;
using System.Collections;

public class Item : Movement
{
	public string Name;

	protected override void Start ()
	{
		base.Start ();
		Initiate();
		Physics2D.raycastsStartInColliders = false;
		this.gameObject.GetComponent<Creature>().AddUse += Use; //Check to make sure it's only running once.
		this.gameObject.GetComponent<Creature>().AddDamage(Damage);
	}


	public void Unequip ()
	{
		this.gameObject.GetComponent<Creature>().AddUse -= Use;
		this.gameObject.GetComponent<Creature>().RemoveDamage(Damage);
	}

	protected virtual void Use () {}

	protected virtual void Initiate (){}

}
