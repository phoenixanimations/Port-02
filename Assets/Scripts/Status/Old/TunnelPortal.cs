using UnityEngine;
using System.Collections;

public class TunnelPortal : StatusFoundation 
{
	protected override void Status ()
	{
		base.Status ();
		Hit = Physics2D.Raycast(transform.position,Front,x);
		if (Hit.collider != null)
		{
			Hit = Physics2D.Raycast(transform.position,-Front,x);
			if (Hit.collider == null)
			{
				Hit = Physics2D.Raycast(transform.position,Front,x);
				Hit.collider.transform.position = (transform.position + (Vector3.Scale(new Vector3(x,y,0),-Front)));
			}
		}
	}
}
