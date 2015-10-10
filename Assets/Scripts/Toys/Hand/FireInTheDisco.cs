using UnityEngine;
using System.Collections;

public class FireInTheDisco : ItemFoundation
{

	protected override void Initiate ()
	{
		base.Initiate ();
		Damage = 3;
		Name = "Don't you know why we keep starting fires?";
	}

	protected override void Use ()
	{
		base.Use ();
		Hit = Physics2D.Raycast(transform.position + (Front * x),Front,1.5f);
		if (Hit.collider != null)
			Hit.collider.gameObject.AddComponent<OnFire>();
	}

}
