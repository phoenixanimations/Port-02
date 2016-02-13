using UnityEngine;
using System.Collections;
using System_Control;

public class Absorb_Energy : Status_Foundation 
{

	public override void Counter_Attack_Status (Phase Activate_On_What_Phase, Creature Advisory, Attack Advisory_Attack)
	{
		base.Counter_Attack_Status (Activate_On_What_Phase, Advisory, Advisory_Attack);
		if (Activate_On_What_Phase == Phase.Counter_Attack_Begin)
		{
			if (Creature_Attack.Adversary.Get_Stat(Stat.Energy) >= 10f)
			{
				Creature_Attack.Adversary.Get_Stat(Stat.Energy, -10f);
				Creature.Get_Stat(Stat.Energy,10f);
			}
		}
	
	}

}
