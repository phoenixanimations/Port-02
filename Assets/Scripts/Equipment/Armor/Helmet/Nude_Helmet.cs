﻿using UnityEngine;
using System.Collections;
using System_Control;

public class Nude_Helmet : Equipment_Foundation
 {
	protected override void Start ()
	{
		ModifyHitpoints(10 * Tier.Formula(Equip_Level));
		base.Start ();
	}
}
