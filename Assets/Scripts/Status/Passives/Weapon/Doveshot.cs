using UnityEngine;
using System.Collections;
using System_Control;

public class Doveshot : Status_Foundation 
{

	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Begin)
		{
			Creature_Attack.Number_Of_Attacks *= 2;
		}	
	}

}
