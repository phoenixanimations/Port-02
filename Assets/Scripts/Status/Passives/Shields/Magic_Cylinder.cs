using UnityEngine;
using System.Collections;
//Magic Cylinder but you still take damage.
public class Magic_Cylinder : Status_Foundation 
{
	public override void Counter_Attack_Status (System_Control.Phase Phase, Creature Advisory, Attack Advisory_Attack)
	{
		base.Counter_Attack_Status (Phase, Advisory, Advisory_Attack);
		if (Phase == System_Control.Phase.Counter_Attack_Hit)
		{
			Advisory.Get_Stat(System_Control.Stat.Hitpoints,Advisory_Attack.Damage);
		}
	}
}
