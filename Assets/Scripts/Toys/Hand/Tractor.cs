using UnityEngine;
using System.Collections;

public class Tractor : ItemFoundation 
{
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
			AddTractor(Front);
		}
		
		if (!LightSwitch)
		{
			RemoveTractor(-Front);
		}
	}
	
	private void AddTractor (Vector3 Direction)
	{
		Hit = Physics2D.Raycast(transform.position,Direction,x);

		if (Hit.collider == null) LightSwitch = false;

		if (Hit.collider != null && Hit.collider.GetComponent<Follow>() == null)
		{
			Hit.collider.gameObject.AddComponent<Follow>();
			Hit.collider.gameObject.GetComponent<Follow>().Name = gameObject.name;
		}
	}
	
	private void RemoveTractor (Vector3 Direction)
	{
		Hit = Physics2D.Raycast(transform.position,Direction,x);
		if (Hit.collider != null && Hit.collider.GetComponent<Follow>() != null)
		{
			Hit.collider.GetComponent<Follow>().Deactivate();
		}
		Hit = Physics2D.Raycast(transform.position,-Direction,x);
		if (Hit.collider != null && Hit.collider.GetComponent<Follow>() != null)
		{
			Hit.collider.GetComponent<Follow>().Deactivate();
		}
	}
}
