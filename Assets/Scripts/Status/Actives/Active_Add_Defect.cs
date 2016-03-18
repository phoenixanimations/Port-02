using UnityEngine;
using System.Collections;
using System_Control;

public class Active_Add_Defect : Active_Foundation 
{
	public Defect_Foundation Select_Defect;
	public bool Is_It_Bleed;

	protected override void Attack_Hit ()
	{
		base.Attack_Hit ();
		if (Is_It_Bleed)
		{
			Select_Defect.Turn = 5f;
			Select_Defect.Modify_Stat = Creature_Attack.Damage * .2f;
			Select_Defect.Assign_Status(Creature_Attack.Adversary.gameObject);
			Creature_Attack.Adversary.Defects.Add(Select_Defect);
			return;
		}
		else 
		{
			Creature_Attack.Adversary.Defects.Add(Select_Defect);
		}
	}
}