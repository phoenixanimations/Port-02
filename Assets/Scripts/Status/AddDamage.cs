using UnityEngine;
using System.Collections;

public class AddDamage : Status {
	public bool OnceOnly = true;

	protected override void Start ()
	{
		base.Start ();
		Damage = 10;
	}

	protected override void Activate ()
	{
		base.Activate ();
		if (OnceOnly)
		this.gameObject.GetComponent<Creature>().Damage+=Damage;
		OnceOnly = false; 
	}

	public override void Deactivate ()
	{
		base.Deactivate ();
		this.gameObject.GetComponent<Creature>().Damage-=Damage;
	}






}
