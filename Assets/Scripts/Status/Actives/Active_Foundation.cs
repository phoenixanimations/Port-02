﻿using UnityEngine;
using System.Collections;
using System_Control;

public class Active_Foundation : Status_Foundation 
{
	public float Energy_Amount;
	private bool Minus_Energy;
	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		Insert_Energy_Amount();
		if (Activate_On_What_Phase == Phase.Attack_Begin)
		{
			if (Creature.Get_Stat(Stat.Energy) >= Energy_Amount)
			{
				Creature.Get_Stat(Stat.Energy, -Energy_Amount);
				Minus_Energy = true;
				Active_Status ();
			}
		}

		if (Activate_On_What_Phase == Phase.Attack_Miss)
		{
			if (Minus_Energy)
				Creature.Get_Stat(Stat.Energy, Energy_Amount);
		}
	}

	protected virtual void Insert_Energy_Amount()
	{

	}

	protected virtual void Active_Status ()
	{

	}


}