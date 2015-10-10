using UnityEngine;
using System.Collections;

public class Duplicator : ItemFoundation 
{

	private GameObject DuplicateCreature;
	private bool LightSwitch;

	protected override void Initiate ()
	{
		base.Initiate ();
		Name = "Duplicator";
	}

	protected override void Use ()
	{
		base.Use ();
		Hit = Physics2D.Raycast(transform.position,Front,x);
		if (Hit.collider != null)
		{
			DuplicateCreature = Hit.collider.gameObject;
			Hit = Physics2D.Raycast(transform.position,-Front,x);
			if (Hit.collider == null)
			{
				Instantiate(DuplicateCreature,transform.position + Vector3.Scale(new Vector3(x,y,0),-Front),transform.rotation);
			}
		}
		DuplicateCreature = null;
	}

}
