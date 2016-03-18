using UnityEngine;
using System.Collections;
using System_Control;

public class Active_Foundation : Status_Foundation 
{
	public float Energy_Amount;

	public override void Attack_Status (System_Control.Phase Activate_On_What_Phase)
	{
		base.Attack_Status (Activate_On_What_Phase);
		if (Activate_On_What_Phase == Phase.Pre_Attack)
		{
			Insert_Energy_Amount();
			if (Creature.Get_Stat(Stat.Energy) >= Energy_Amount)
				Active_Status ();
		}

		if (Activate_On_What_Phase == Phase.Attack_Hit)
		{
			Activate_Once = false;
		}
	}

	public override void End_Of_Turn ()
	{
		base.End_Of_Turn ();
		if (!Activate_Once)
		{
			if (Creature.Get_Stat(Stat.Energy) >= Energy_Amount)
				Creature.Get_Stat(Stat.Energy, -Energy_Amount/2f);
		}
	}

	protected virtual void Insert_Energy_Amount()
	{

	}

	protected virtual void Active_Status ()
	{

	}
}
