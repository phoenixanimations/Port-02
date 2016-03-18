using UnityEngine;
using System.Collections;
using System_Control;
//Deflect returned whichever defects you got from being attacked to the enemy
public class Deflect_Defect : Status_Foundation 
{
	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Attack_Hit)
		{
			if (Creature.Defects.Count > 0)
			{
				float Random_Defect = Random.Range(0,Creature.Defects.Count);
				Creature_Attack.Adversary.Defects.Add(Creature.Defects[(int)Random_Defect]);
			}
		}
	}
}
