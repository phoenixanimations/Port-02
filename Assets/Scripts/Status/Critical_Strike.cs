using UnityEngine;
using System.Collections;
using System_Control;

public class Critical_Strike : Status_Foundation 
{
	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Begin)
		{
			//??? These all seem like stat modifactions for the weapon why is this a passive?
			//Sets damage equal to Tier of weapon, weapon's Critical Damage becomes 15000% (100% Critical chance)
		}
	}
}
