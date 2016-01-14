//using UnityEngine;
//using System.Collections;
//
//public class StickOfGum : ItemFoundation
//{
//
//	protected override void Initiate ()
//	{
//		base.Initiate ();
//		Name = "Just an ordinary piece of gum";
//	}
//
//	protected override void Use ()
//	{
//		base.Use ();
//		Hit = Physics2D.Raycast(transform.position,Front);
//		if (Hit.collider != null && Hit.collider.GetComponent<TunnelPortal>() == null)
//		{
//			Hit.collider.gameObject.AddComponent<TickingBomb>();
//		}
//	}
//
//}
