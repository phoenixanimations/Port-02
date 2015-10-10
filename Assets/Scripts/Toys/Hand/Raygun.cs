using UnityEngine;
using System.Collections;

public class Raygun : ItemFoundation 
{
	protected override void Initiate ()
	{
		base.Initiate ();
		Damage = 20;
		Name = "Raygun";
	}

	protected override void Use ()
	{
		base.Use ();
		
		
		if (Front.y == -1 || Front.y == 1)
		{
			beam (transform.position);
			beam(transform.position + new Vector3(x,0,0));
			beam(transform.position + new Vector3(-x,0,0));
			return;
		}
		
		beam(transform.position);
		beam(transform.position + new Vector3(0,x,0));
		beam(transform.position + new Vector3(0,-x,0));
		
	}

	private void beam (Vector3 Origin)
	{
		HitArray = Physics2D.RaycastAll(Origin,Front,10f);
		if (HitArray.Length > 0)
		{
			for (int i = (HitArray.Length - 1); i >= 0; i--)
			{
				HitArray[i].collider.GetComponent<Creature>().RemoveHealth(GetComponent<Creature>().Damage);	
			}
		}
	}
}
