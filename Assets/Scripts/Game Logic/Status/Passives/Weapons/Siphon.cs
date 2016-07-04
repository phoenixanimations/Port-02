using UnityEngine;
using System.Collections;
using System_Control;

public class Siphon : Status_Foundation 
{
	public float Siphon_Energy;

	public override void Activate (Creature_States Creature, Raycast Raycast, State State, Attack Attack)
	{
		base.Activate (Creature, Raycast, State, Attack);
		if (State == State.Attack_Begin)
		{
			if (Attack.Advisory.Get_Stat(Stat.Energy) >= Siphon_Energy)
			{
				Attack.Advisory.Get_Stat(Stat.Energy, -Siphon_Energy);
				Creature.Get_Stat(Stat.Energy, Siphon_Energy);
			}
		}
	}
}
