﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Double_Healing_Amount : Status_Foundation 
{
	public override void Activate (Creature_States Creature, Raycast Raycast, System_Control.State State, Attack Attack)
	{
		base.Activate (Creature, Raycast, State, Attack);
		if (State == State.Beginning_Of_Turn)
		{
//			Creature.Heal_Bonus.Add(2); ????
		}
	}
}