using UnityEngine;
using System.Collections;
using System_Control;

public class Melee_Vanilla_One_Handed : Weapon_Foundation
{

protected override void Start ()
	{
 		ModifyDamage(ModifyMeleeDamage:1.5f * Tier.Formula(Equip_Level));
		ModifyAccuracy(Tier.Formula(Equip_Level));
		ModifyEvade(Tier.Formula(Equip_Level));
		base.Start ();

	}

}
