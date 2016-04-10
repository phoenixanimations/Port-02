using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Double_Healing_Amount : Status_Foundation 
{
	public override void Activate (Creature_States Creature, Raycast Raycast, System_Control.State State)
	{
		base.Activate (Creature, Raycast, State);
		if (State == State.BeginningOfTurn)
		{
//			Creature.Heal_Bonus.Add(2); ????
		}
	}
}
