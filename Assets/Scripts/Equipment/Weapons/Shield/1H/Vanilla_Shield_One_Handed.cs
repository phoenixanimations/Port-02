using UnityEngine;
using System.Collections;
using System_Control;

public class Vanilla_Shield_One_Handed : Equipment_Foundation
 {
	protected override void Start ()
	{
		ModifyHitpoints(20 * Tier.Formula(Equip_Level));
		base.Start ();	
	}
}
