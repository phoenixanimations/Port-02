using UnityEngine;
using System.Collections;
using System_Control;

public class Armor_Base : Equipment_Foundation
 {

	protected override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Get_Stat(Stat.Equip_Level,1f,true);
		Get_Stat(Stat.Hitpoints,10,Stat.Equip_Level);
		Subclass = Assign_Subclass.None;
	}
}
