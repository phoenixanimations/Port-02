using UnityEngine;
using System.Collections;
using System_Control;

public class Parry : Status_Foundation 
{
	/*
	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Counter_Attack_Hit)
		{
			if (Activate_Once)
			{
				Activate_Once = false;
				//Creature_Attack.Hit_Me_Baby(Creature_Equipment);
			}
		}
	}*/
	public override void Activate (Creature_States Creature, Raycast Raycast, State State, Attack Attack)
	{
		base.Activate (Creature, Raycast, State, Attack);
		
		if (State == State.Counter_Attack_Hit)
		{
			
		}
	}
}
