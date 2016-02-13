using UnityEngine;
using System.Collections;
using System_Control;

public class Splitshot : Active_Foundation 
{
	protected override void Insert_Energy_Amount ()
	{
		base.Insert_Energy_Amount ();
		Energy_Amount = 30;
	}
	protected override void Active_Status ()
	{
		base.Active_Status ();
		Creature_Attack.Number_Of_Attacks *= 2f;
	}
}
