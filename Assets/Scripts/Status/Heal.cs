using UnityEngine;
using System.Collections;

public class Heal : StatusFoundation {
	protected int AddHeal = 10;

	protected override void Status ()
	{
		base.Status ();
		Cache.AddHealth(AddHeal);
	}
}
