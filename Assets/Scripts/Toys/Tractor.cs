using UnityEngine;
using System.Collections;

public class Tractor : Item {

	private bool LightSwitch;

	protected override void Initiate ()
	{
		base.Initiate ();
		Name = "Tractor Beam";
	}


	protected override void Use ()
	{
		base.Use ();
		LightSwitch = !LightSwitch;

		if (LightSwitch)
		{


			Hit = Physics2D.Raycast(transform.position,transform.right,x);
			if (Hit.collider != null && gameObject.GetComponent<Follow>() == null) 
				gameObject.AddComponent<Follow>();

			Hit = Physics2D.Raycast(transform.position,-transform.right,x);
			if (Hit.collider != null && gameObject.GetComponent<Follow>() == null) 
				gameObject.AddComponent<Follow>();

			Hit = Physics2D.Raycast(transform.position,transform.up,x);
			if (Hit.collider != null && gameObject.GetComponent<Follow>() == null) 
				gameObject.AddComponent<Follow>();

			Hit = Physics2D.Raycast(transform.position,-transform.up,x);
			if (Hit.collider != null && gameObject.GetComponent<Follow>() == null) 
				gameObject.AddComponent<Follow>();

		}

		if (!LightSwitch)
		{
			if (gameObject.GetComponent<Follow>() != null)
			{
				gameObject.GetComponent<Follow>().Deactivate();
				Destroy(gameObject.GetComponent<Follow>());
			}
		}
	}

}
