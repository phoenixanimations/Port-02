using UnityEngine;
using System.Collections;

public class Follow : Status {

	protected override void Activate ()
	{
		base.Activate ();
		Hit = Physics2D.Raycast(transform.position,transform.right,(x * 2));
		if (Hit.collider != null)
		Hit.collider.transform.position = (transform.position + new Vector3 (x,0,0));

		Hit = Physics2D.Raycast(transform.position,transform.up,(x * 2));
		if (Hit.collider != null)
		Hit.collider.transform.position = (transform.position + new Vector3 (0,y,0));

		Hit = Physics2D.Raycast(transform.position,-transform.right,(x * 2));
		if (Hit.collider != null)
		Hit.collider.transform.position = (transform.position + new Vector3 (-x,0,0));

		Hit = Physics2D.Raycast(transform.position,-transform.up,(x * 2));
		if (Hit.collider != null)
		Hit.collider.transform.position = (transform.position + new Vector3 (0,-y,0));

		Diagonal (transform.up + transform.right);
		Diagonal (transform.up + -transform.right);
		Diagonal (-transform.up + -transform.right);
		Diagonal (-transform.up + transform.right);

	}

	private void Diagonal (Vector3 Direction)
	{
//		HitArray = Physics2D.RaycastAll(transform.position,Direction,(x * 2));
//		if (Hit.collider != null)
//		{
//			foreach (RaycastHit2D Collided in HitArray)
//			{
//
//					if (Collided.transform.position == (gameObject.transform.position + (new Vector3 (x,y,0) * Direction)))
//					Collided.collider.transform.position = (transform.position + (new Vector3 (x,y,0) * Direction));
//			}
//		}
	}

}
