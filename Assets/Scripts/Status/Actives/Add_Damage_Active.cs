using UnityEngine;
using System.Collections;

public class Add_Damage_Active : Active_Foundation 
{
	public float Damage;
	protected override void Active_Status ()
	{
		base.Active_Status ();
		Creature_Attack.Damage_Bonus.Add(Damage);
	}
}
