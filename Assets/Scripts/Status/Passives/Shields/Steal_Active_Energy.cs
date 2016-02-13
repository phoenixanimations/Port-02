using UnityEngine;
using System.Collections;
using System_Control;
//Any energy that your enemy lost when they attacked is given to you (100% Ability = you gain 100% Energy)
public class Steal_Active_Energy : Status_Foundation 
{
	private float Record_Energy;
	public override void Counter_Attack_Status (System_Control.Phase Activate_On_What_Phase, Creature Advisory, Attack Advisory_Attack)
	{
		base.Counter_Attack_Status (Activate_On_What_Phase, Advisory, Advisory_Attack);
		if (Activate_On_What_Phase == Phase.Counter_Attack_Begin)
		{
			Record_Energy = Advisory.Get_Stat(Stat.Energy);
		}
		if (Activate_On_What_Phase == Phase.Counter_Attack_End)
		{
			if (Advisory.Get_Stat(Stat.Energy) != Record_Energy)
			{
				Debug.Log("Record Energy amounts in attack.");
			}
		}

	}
}
