using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Critical_Recursion : Status_Foundation 
{
	private List<float> Log_Attack_Amount = new List<float>();

	private void Compare_Attack_To_Last_Attack()
	{
		if (Log_Attack_Amount.Count > 1)
		{
			if (Log_Attack_Amount[0] < Log_Attack_Amount[1])
			{	
				Creature_Attack.Number_Of_Attacks++;
				Log_Attack_Amount.RemoveAt(0);
				Creature_Attack.Critical_Damage_Bonus.Add(10f);
			}
		}
	}

	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);

		if (Activate_On_What_Phase == Phase.Attack_End)
		{
				Compare_Attack_To_Last_Attack();
		}
	}
}
