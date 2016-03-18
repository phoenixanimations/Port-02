using UnityEngine;
using System.Collections;

public class Active_Add_Damage : Active_Foundation 
{
	public float Damage;

	protected override void Attack_Change_Stats ()
	{
		base.Attack_Change_Stats ();
		Creature_Attack.Damage_Bonus.Add(Damage);
	}
}
