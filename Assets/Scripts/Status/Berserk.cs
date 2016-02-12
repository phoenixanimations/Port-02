using UnityEngine;
using System.Collections;
using System_Control;

public class Berserk : Status_Foundation 
{
	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Begin)
		{
			if ((Creature.Get_Stat(Stat.Hitpoints)/Creature.Max_Health()) < .5f)
			{
				Creature_Attack.Damage_Bonus.Add(2);
			}
			
		}
	}
}
