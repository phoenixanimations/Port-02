using UnityEngine;
using System.Collections;
using System_Control;

public class Healing_Strike : Status_Foundation
 {
	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Hit)
		{
			Creature.Heal(Creature_Attack.Damage * 50f);
		}
	}
}
