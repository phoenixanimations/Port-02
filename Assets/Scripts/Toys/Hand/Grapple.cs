using UnityEngine;
using System.Collections;

public class Grapple : ItemFoundation {
	public float Distance = 15f;
	protected override void Initiate ()
	{
		base.Initiate ();
		Damage = 2;
		Name = "Crash and Burn";
	}

	protected override void Use ()
	{
		base.Use ();
		Hit = Physics2D.Raycast(transform.position,Front,Distance);
		if (Hit.collider != null)
		{
			while (transform.position != Hit.collider.transform.position - (Vector3.Scale(new Vector3(x,y,0),Front)))
				gameObject.GetComponent<Creature>().Move(Front);
		}
	}
}
