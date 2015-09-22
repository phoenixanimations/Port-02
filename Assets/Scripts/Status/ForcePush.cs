using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ForcePush : Status
{

	private float Push = 15f;
	private int Distance = 15;
	protected override void Activate ()
	{
		base.Activate ();

		HitArray = Physics2D.RaycastAll(transform.position,transform.up,Push);
		if (HitArray.Length > 0)
		{
			PushMoveAmount ("Up");
		}

		HitArray = Physics2D.RaycastAll(transform.position,-transform.up,Push);
		if (HitArray.Length > 0)
		{
			PushMoveAmount ("Down");
		}

		HitArray = Physics2D.RaycastAll(transform.position,transform.right,Push);
		if (HitArray.Length > 0)
		{
			PushMoveAmount ("Right");
		}

		HitArray = Physics2D.RaycastAll(transform.position,-transform.right,Push);
		if (HitArray.Length > 0)
		{
			PushMoveAmount ("Left");
		}

	}

	private void PushMoveAmount (string Direction)
	{
		for (int i = (HitArray.Length - 1); i >= 0; i--)
		{
			for (int iAmount = 0; iAmount < Distance; iAmount++)
				HitArray[i].collider.GetComponent<Creature>().Move(Direction);	
		}
	}


	
}
