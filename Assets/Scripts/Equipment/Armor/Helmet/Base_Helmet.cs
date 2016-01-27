using UnityEngine;
using System.Collections;
using System_Control;

public class Base_Helmet : Armor_Base
{
	protected override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Subclass = Assign_Subclass.Helmet;
	}
}
