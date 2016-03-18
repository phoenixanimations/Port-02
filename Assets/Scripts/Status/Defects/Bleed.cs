using UnityEngine;
using System.Collections;
using System_Control;

public class Bleed : Defect_Foundation
{
	public override void Beginning_Of_Turn ()
	{
		base.Beginning_Of_Turn ();
		Creature.Get_Stat(Stat.Hitpoints,-Modify_Stat * .2f);
	}
}