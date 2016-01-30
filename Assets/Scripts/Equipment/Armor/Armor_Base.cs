using UnityEngine;
using System.Collections;
using System_Control;

public class Armor_Base : Equipment_Foundation
 {

	public override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Get_Stat(Stat.Item_Tier,1f,true);
		Get_Stat(Stat.Hitpoints,10,Stat.Item_Tier);
		Subclass = Assign_Subclass.None;
	}
}
