using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Critical_Recursion : Status_Foundation 
{
	private List<float> Log_Attack_Amount = new List<float>();
	private float Critical_Damage = 0f;
	private float Critical_Chance = 0f;
//	private float Accuracy = 0f;

	private void Compare_Attack_To_Last_Attack()
	{
		if (Log_Attack_Amount.Count > 1)
		{
			if (Log_Attack_Amount[0] < Log_Attack_Amount[1])
			{
				
				Creature_Attack.How_Many_Times++;
				Log_Attack_Amount.RemoveAt(0);
			}
		}
	}

	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);

		if (Activate_On_What_Phase == Phase.Attack_Begin)
		{
			Creature_Attack.Critical_Chance += Critical_Chance;
			Creature_Attack.Critical_Damage += Critical_Damage;
//			Accuracy *= 

		}

		if (Activate_On_What_Phase == Phase.Attack_End)
		{
				Log_Attack_Amount.Add(Creature_Attack.Damage);
				Compare_Attack_To_Last_Attack();
		}
	}

	public override void End_Of_Turn ()
	{
		base.End_Of_Turn ();
		Critical_Damage = 0f;
		Critical_Chance = 0f;
//		Accuracy = 0f;
		Log_Attack_Amount.Clear();
	}

	

}
