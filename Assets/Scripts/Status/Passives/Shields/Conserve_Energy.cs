using UnityEngine;
using System.Collections;
using System_Control;

public class Conserve_Energy : Status_Foundation 
{
	private bool Did_You_Attack;
	public override void Attack_Status (Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Begin)
		{
			Did_You_Attack = true;
		}
	}
	public override void End_Of_Turn ()
	{
		base.End_Of_Turn ();
		if (Did_You_Attack == false)
		{
			Creature.Get_Stat(Stat.Energy,50f);
		}
		Did_You_Attack = false;
		
	}

}
