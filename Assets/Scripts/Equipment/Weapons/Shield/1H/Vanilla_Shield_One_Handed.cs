﻿using UnityEngine;
using System.Collections;
using System_Control;

public class Vanilla_Shield_One_Handed : Equipment_Foundation
 {
	protected override void Awake ()
	{
		base.Awake ();
		Get_Stat(Stat.Equip_Level,1f,true);
		Get_Stat(Stat.Hitpoints,20 * Tier.Formula(Get_Stat(Stat.Equip_Level)));
	}
}
