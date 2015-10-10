using UnityEngine;
using System;
using System.Collections;

public class ItemFoundation : Movement
{
	public string Name;
	protected Creature Cache;

	protected override void Start ()
	{
		base.Start ();
		Initiate();
		Physics2D.queriesStartInColliders = false;
		Cache = gameObject.GetComponent<Creature>();
		Cache.AddUse += Use;
		Cache.AddDamage(Damage);
	}

	public void Unequip ()
	{
		Cache.AddUse -= Use;
		Cache.RemoveDamage(Damage);
		Destroy(this);
	}

	protected virtual void Use ()
	{
		ModifyFront(Cache.Front);
	}

	protected virtual void Initiate (){}
}