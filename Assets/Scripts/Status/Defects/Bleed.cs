using UnityEngine;
using System.Collections;
using System_Control;

public class Bleed : Defect_Foundation
{
	bool Did_You_Move;
	public override void Beginning_Of_Turn ()
	{
		base.Beginning_Of_Turn ();
		Creature.Get_Stat(Stat.Hitpoints,-Modify_Stat * .2f);	
		Did_You_Move = false;
	}

	public override void Attack_Status (Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Move)
		{
			Did_You_Move = true;
		}
	}

	public override void End_Of_Turn ()
	{
		base.End_Of_Turn ();
		if (Did_You_Move)
		{
			Creature.Get_Stat(Stat.Hitpoints,-Modify_Stat * 3f);
		}
	}
}