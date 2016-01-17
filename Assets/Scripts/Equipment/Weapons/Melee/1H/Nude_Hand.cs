using UnityEngine;
using System.Collections;
using System_Control;

public class Nude_Hand : Melee_Vanilla_One_Handed
{
protected override void Awake ()
	{
		base.Awake ();
		Get_Stat(Stat.Melee_Damage,Tier.Formula(2f));
	}

}
