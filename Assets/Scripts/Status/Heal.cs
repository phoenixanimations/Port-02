using UnityEngine;
using System.Collections;

public class Heal : Status {

	public int Damage = 0;
	
	protected override void Start ()
	{
		base.Start ();
		
		this.gameObject.GetComponent<Creature>().AddStatus += thisWorks;
	}
	
	
	private void thisWorks ()
	{
		//this.gameObject.GetComponent<Creature>().Bonus = Damage;
	}
}
