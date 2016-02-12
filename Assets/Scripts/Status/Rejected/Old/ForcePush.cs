//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class ForcePush : StatusFoundation {
//	private float Push = 15f;
//	private int Distance = 15;
//
//	protected override void Status ()
//	{
//		base.Status ();
//		HitArray = Physics2D.RaycastAll(transform.position,transform.up,Push);
//		if (HitArray.Length > 0)
//		{
//			PushMoveAmount (Vector3.up);
//		}
//		
//		HitArray = Physics2D.RaycastAll(transform.position,-transform.up,Push);
//		if (HitArray.Length > 0)
//		{
//			PushMoveAmount (Vector3.down);
//		}
//		
//		HitArray = Physics2D.RaycastAll(transform.position,transform.right,Push);
//		if (HitArray.Length > 0)
//		{
//			PushMoveAmount (Vector3.right);
//		}
//		
//		HitArray = Physics2D.RaycastAll(transform.position,-transform.right,Push);
//		if (HitArray.Length > 0)
//		{
//			PushMoveAmount (Vector3.left);
//		}
//	}
//
//	private void PushMoveAmount (Vector3 Direction)
//	{
//		for (int i = (HitArray.Length - 1); i >= 0; i--)
//		{
//			for (int iAmount = 0; iAmount < Distance; iAmount++)
//				HitArray[i].collider.GetComponent<Creature>().Move(Direction);	
//		}
//	}
//
//}
