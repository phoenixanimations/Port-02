using UnityEngine;
using System.Collections;
using System_Control;

public class Active_Foundation : Status_Foundation 
{
	public float Cost;
	public override void Activate (Creature_States Creature, Raycast Raycast, System_Control.State State, Attack Attack)
	{
		base.Activate (Creature, Raycast, State, Attack);
		if (State == State.Attack)
		{
			if (Creature.Get_Stat(Stat.Energy) > Cost)
			{
				Creature.Get_Stat(Stat.Energy,-Cost);
			}
		}

		if (State == State.Attack_Begin)
		{
			Attack.Dont_Negate_Energy = false;
		}
	}
		
}
