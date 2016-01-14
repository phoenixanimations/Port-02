//using UnityEngine;
//using System.Collections;
//
//public class WalkHeal : Heal
//{
//	private Vector3 RecordMovement;
//
//	protected override void Start ()
//	{
//		base.Start ();
//		AddHeal = 0;
//	}
//
//	protected override void Status ()
//	{
//		base.Status ();	
//		AddHeal = 1;
//	}
//
//	protected override void CleanUpStatus ()
//	{
//		base.CleanUpStatus ();
//		if (RecordMovement == transform.position) AddHeal = 0;
//		RecordMovement = transform.position;
//	}
//
//}
