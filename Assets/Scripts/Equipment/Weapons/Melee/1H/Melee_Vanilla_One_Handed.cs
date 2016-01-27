using UnityEngine;
using System.Collections;
using System_Control;

public class Melee_Vanilla_One_Handed : Weapon_Foundation
{

	public Status_Foundation Passive;

	protected override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Get_Stat(Stat.Melee_Damage,1.5f, Stat.Equip_Level);
		Get_Stat(Stat.Accuracy,1f,Stat.Equip_Level);
		Get_Stat(Stat.Evade,0.5f,Stat.Equip_Level);
		Class = Assign_Class.Melee;
		Subclass = Assign_Subclass.One_Handed;
		
	}

}
