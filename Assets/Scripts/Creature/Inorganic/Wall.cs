using UnityEngine;
using System.Collections;

public class Wall : Creature 
{

	protected override void Start ()
	{
		Health = 100;
		base.Start ();

	}

	public override void AI ()
	{

		if (Random.Range(-500000,10000) > 9990)
		gameObject.GetComponent<Creature>().Move("Right");
		if (Random.Range(-500000,10000) > 9000)
			gameObject.GetComponent<Creature>().Move("Up");
		if (Random.Range(-500000,10000) > 9500)
			gameObject.GetComponent<Creature>().Move("Left");
		if (Random.Range(-500000,10000) > 9700)
			gameObject.GetComponent<Creature>().Move("Down");
	}


}
