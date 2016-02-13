using UnityEngine;
using System.Collections;

public class Melee_200 : Active_Foundation 
{
	protected override void Insert_Energy_Amount ()
	{
		base.Insert_Energy_Amount ();
		Energy_Amount = 20f;
	}

	protected override void Active_Status ()
	{
		base.Active_Status ();
		Creature_Attack.Damage_Bonus.Add(2f);
	}
}
