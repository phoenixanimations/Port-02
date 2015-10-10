using UnityEngine;
using System.Collections;

public class TunnelGun : ItemFoundation 
{

	protected override void Initiate ()
	{
		base.Initiate ();
		Damage = 0;
		Name = "Hole in one.";
	}

	protected override void Use ()
	{
		base.Use ();
		Hit = Physics2D.Raycast(transform.position,Front);
		if (Hit.collider != null && Hit.collider.GetComponent<TunnelPortal>() == null)
		{
			Hit.collider.gameObject.AddComponent<TunnelPortal>();
		}
	}

}
