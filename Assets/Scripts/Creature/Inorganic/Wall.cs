using UnityEngine;
using System.Collections;

public class Wall : Creature 
{
	protected override void Start ()
	{
		base.Start ();
		Hitpoints = 100;
	}

	public override void AI ()
	{
		if (Random.Range(-500000,10000) > 9990)
			gameObject.GetComponent<Creature>().Move(Vector3.right);
		if (Random.Range(-500000,10000) > 9000)
			gameObject.GetComponent<Creature>().Move(Vector3.up);
		if (Random.Range(-500000,10000) > 9500)
			gameObject.GetComponent<Creature>().Move(Vector3.left);
		if (Random.Range(-500000,10000) > 9700)
			gameObject.GetComponent<Creature>().Move(Vector3.down);
	}
}
