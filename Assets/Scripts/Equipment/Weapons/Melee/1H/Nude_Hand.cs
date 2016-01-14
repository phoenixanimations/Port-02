using UnityEngine;
using System.Collections;
using System_Control;

public class Nude_Hand : Melee_Vanilla_One_Handed
{

protected override void Start ()
	{
		ModifyDamage(Tier.Formula(Equip_Level * 2));
		base.Start ();

	}

}
