using UnityEngine;
using System.Collections;
using System_Control;
public class Berserk : Status_Foundation
{
	
	public override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Creature_Attack = Creature.GetComponent<Attack>();
	}

	public override void Beginning_Of_Turn ()
	{
		base.Beginning_Of_Turn ();
	}

	public override void Attack_Status (Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
				
		if (Activate_On_What_Phase == Phase.Attack_Hit)
		{

			Debug.Log(Activate_On_What_Phase);
		}
		
		if (Activate_On_What_Phase == Phase.Attack_Hit)
		{
			if (Creature.Get_Stat(Stat.Energy) >= 100 )
			{
				Creature_Attack.Damage *= 2;
				Creature.Get_Stat(Stat.Energy, -100);
			}
		}
		
	}

}