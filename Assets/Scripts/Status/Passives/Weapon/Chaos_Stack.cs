using UnityEngine;
using System.Collections;

public class Chaos_Stack : Status_Foundation 
{
	private float Chaos_Limit = 1f;

	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == System_Control.Phase.Attack_Begin)
		{
			Creature_Attack.Damage_Bonus.Add((.1f * Chaos_Limit));
		}
		
		if (Activate_On_What_Phase == System_Control.Phase.Attack_Hit)	
		{
			if (Chaos_Limit <= 10)
			{
				Chaos_Limit++;
			}
			if (5f * Chaos_Limit >= UnityEngine.Random.Range(0f,100f))
			{
				Creature.Get_Stat(System_Control.Stat.Hitpoints,-Creature_Attack.Damage);
				Creature_Attack.Adversary.Get_Stat(System_Control.Stat.Hitpoints,Creature_Attack.Damage);
			}

		}
	}

}
