using UnityEngine;
using System.Collections;
//All healing effects are doubled
public class Double_Healing_Amount : Status_Foundation 
{
	public override void Beginning_Of_Turn ()
	{
		base.Beginning_Of_Turn ();
		Creature.Heal_Bonus.Add(2);
	}
}
