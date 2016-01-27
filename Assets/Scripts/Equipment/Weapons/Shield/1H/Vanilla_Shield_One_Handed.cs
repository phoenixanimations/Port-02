﻿using UnityEngine;
using System.Collections;
using System_Control;

public class Vanilla_Shield_One_Handed : Equipment_Foundation
 {
	protected override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Get_Stat(Stat.Hitpoints,20f,Stat.Equip_Level);
		Get_Stat(Stat.Evade,1.5f,Stat.Equip_Level);
		Get_Stat(Stat.Accuracy,0f, true);
		Subclass = Assign_Subclass.Shield;
	}
}
