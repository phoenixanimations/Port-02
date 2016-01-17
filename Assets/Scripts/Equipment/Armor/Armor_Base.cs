using UnityEngine;
using System.Collections;
using System_Control;

public class Armor_Base : Equipment_Foundation
 {

	protected override void Awake ()
	{
		base.Awake ();
		Get_Stat(Stat.Equip_Level,1f,true);
		Get_Stat(Stat.Hitpoints, 10 * Tier.Formula(Get_Stat(Stat.Equip_Level)));
	}
}
