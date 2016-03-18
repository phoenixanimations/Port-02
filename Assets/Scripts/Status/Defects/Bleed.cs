using UnityEngine;
using System.Collections;
using System_Control;

public class Bleed : Defect_Foundation
{
	private float Damage;
	public override void Beginning_Of_Turn ()
	{
		base.Beginning_Of_Turn ();
		Turn--;
		Creature.Get_Stat(Stat.Hitpoints,-Damage * .2f);
	}
	
	public void Activate (float Assign_Damage)
	{
		Turn = 5f;
		Damage = Assign_Damage;
	}
}