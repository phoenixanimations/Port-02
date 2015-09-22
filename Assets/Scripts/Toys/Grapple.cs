using UnityEngine;
using System.Collections;

public class Grapple : Item {
	protected override void Initiate ()
	{
		base.Initiate ();
		Damage = 2;
		Name = "Crash and Burn";

	}



	protected override void Use ()
	{
		base.Use ();
		Hit = Physics2D.Raycast(transform.position,transform.right,20f);
		if (Hit.collider != null)
		{
			while ((Hit.collider.transform.position - new Vector3(x,0,0)) != transform.position)
			gameObject.GetComponent<Creature>().Move("Right");
		}
	}

}
