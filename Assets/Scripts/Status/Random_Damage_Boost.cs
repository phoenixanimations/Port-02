using UnityEngine;
using System.Collections;
using System_Control;

public class Random_Damage_Boost : Status_Foundation
{
	public float Damage_Max_RNG_Boost_Percent = 200f;
	public override void Attack_Status (Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Hit)
		{
			Creature_Attack.Damage *= 1 + UnityEngine.Random.Range(0f,Damage_Max_RNG_Boost_Percent);
		}
	}	
	
}
