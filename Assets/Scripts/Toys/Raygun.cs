using UnityEngine;
using System.Collections;

public class Raygun : Item {

	protected override void Initiate ()
	{
		base.Initiate ();
		Damage = 10;
		Name = "Raygun";
	}

	protected override void Use ()
	{
		base.Use ();
		beam(transform.position);
		beam(transform.up);
		beam(-transform.up);
	
	}

	private void beam (Vector3 Origin)
	{
		HitArray = Physics2D.RaycastAll(Origin,transform.right,10f);
		if (HitArray.Length > 0)
		{
			for (int i = (HitArray.Length - 1); i >= 0; i--)
			{
				HitArray[i].collider.GetComponent<Creature>().RemoveHealth(Damage);	
			}
		}
	}


}
