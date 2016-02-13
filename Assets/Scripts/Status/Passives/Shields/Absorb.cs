using UnityEngine;
using System.Collections;
using System_Control;
//Raven: Negate all damage, heal 1:1 what you would have taken//
public class Absorb : Status_Foundation 
{
	public override void Counter_Attack_Status (Phase Activate_On_What_Phase, Creature Advisory, Attack Attack_Advisory)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Counter_Attack_End)
		{
			Creature.Get_Stat(Stat.Hitpoints,(Attack_Advisory.Damage) * 2f);
		}
	}
}
