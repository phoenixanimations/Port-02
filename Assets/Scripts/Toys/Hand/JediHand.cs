using UnityEngine;
using System.Collections;

public class JediHand : ItemFoundation 
{
	public float Distance = 2f;

	protected override void Initiate ()
	{
		base.Initiate();
		Damage = 2;
		Name = "Jedi Hand";
	}

	protected override void Use ()
	{
		base.Use ();
		HitArray = Physics2D.RaycastAll(transform.position,Front,Distance);
		if (HitArray.Length > 0)
		{
			for (int i = (HitArray.Length - 1); i >= 0; i--)
			{
				HitArray[i].collider.GetComponent<Creature>().Move(Front);	
			}
		}
	}
}
