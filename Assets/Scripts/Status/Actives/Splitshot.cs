﻿using UnityEngine;
using System.Collections;
using System_Control;

public class Splitshot : Active_Foundation 
{
	
	protected override void Attack_Change_Stats ()
	{
		base.Attack_Change_Stats ();
		Creature_Attack.Number_Of_Attacks *= 2f;
	}
}
