using UnityEngine;
using System.Collections;
using System_Control;

public class Knockback : Status_Foundation 
{
	public override void Attack_Status (Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Hit)
		{
			
				Creature_Attack.Adversary.Move(Creature.Front);
			
		}
	}
}
