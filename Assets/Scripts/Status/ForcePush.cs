using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ForcePush : Status {

	public int Damage = 0;
	protected int Slot;


	protected override void Start ()
	{
		base.Start ();

		this.gameObject.GetComponent<Creature>().AddStatus += thisWorks;
		this.gameObject.GetComponent<Creature>().AddDamage(Damage);
		ArraySlot();
	}


	private void thisWorks ()
	{
		this.gameObject.GetComponent<Creature>().AddDamage(Slot,Damage);

//		Debug.Log ("hi");

	}

	protected void ArraySlot ()
	{
		Slot = (this.gameObject.GetComponent<Creature>().AddDamage() - 1);

	}

}
