using UnityEngine;
using System.Collections;

public class Jumper : StatusFoundation {
	public float Push = 15f;

	protected override void Status ()
	{
		base.Status ();
		Hit = Physics2D.Raycast(transform.position,transform.right,x);
		if (Hit.collider != null) 
		{
			HitArray = Physics2D.RaycastAll(transform.position,Front,Push);
			Hit = Physics2D.Raycast(HitArray[HitArray.Length - 1].collider.transform.position,Front,x);
			if (HitArray.Length >= 0 && Hit.collider == null)
				transform.position = (HitArray[HitArray.Length - 1].collider.transform.position + new Vector3 (x,0,0));
		}
	}
}
