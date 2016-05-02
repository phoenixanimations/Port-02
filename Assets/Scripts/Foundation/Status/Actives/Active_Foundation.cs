using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;
using System.Linq;

public class Active_Foundation : Status_Foundation 
{
	public float Damage_Bonus_Multiplier;
	public float Scale_Value;
	public List<Status_Foundation> Passives = new List <Status_Foundation>();
	
	public override void Activate (Creature_States Creature, Raycast Raycast, System_Control.State State, Attack Attack)
	{
		base.Activate (Creature, Raycast, State, Attack);
		Passives.ForEach(p => p.Activate(Creature,Raycast,State,Attack));
		
		if (State == State.Attack)
		{
			if (Creature.Get_Stat(Stat.Energy) > Get_Stat(Stat.Energy))
			{
				Creature.Get_Stat(Stat.Energy,-Get_Stat(Stat.Energy));
			}
		}

		if (State == State.Attack_Begin)
		{
			Attack.Dont_Negate_Energy = false;
			Calculate_Bonus_Multipler ();
			Attack.Damage_Bonus_Multiplier.Add(Damage_Bonus_Multiplier);
		}
	}

	public float Calculate_Bonus_Multipler ()
	{
		return (100f + 5f * ((Scale_Value * .1f * Get_Stat(Stat.Energy)) + (.5f * Mathf.Pow((.1f * Get_Stat(Stat.Energy)),2f) - .5f * (.1f * Get_Stat(Stat.Energy))))) / 100f;
	}		
}
