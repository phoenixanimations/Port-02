using UnityEngine;
using System.Collections;
using System_Control;

public class Active_Add_Defect : Active_Foundation 
{
	public Status_Foundation Select_Defect;

	protected override void Attack_Hit ()
	{
		base.Attack_Hit ();
		Creature_Attack.Adversary.Defects.Add(Select_Defect);
	}
}