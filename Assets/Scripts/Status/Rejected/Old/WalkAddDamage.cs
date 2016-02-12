//using UnityEngine;
//using System.Collections;
//
//public class WalkAddDamage : StatusFoundation 
//{
//
//	private Vector3 RecordMovement;
//
//	protected override void Start ()
//	{
//		base.Start ();
//		Damage = 1;
//	}
//
//	protected override void Status ()
//	{
//		base.Status ();
//		Cache.RemoveDamage(Damage);
//		Damage ++;		
//		if (RecordMovement == transform.position) Damage = 1;
//		Cache.AddDamage(Damage);
//		RecordMovement = transform.position;
//	}
//	
//	public override void Deactivate ()
//	{
//		base.Deactivate ();
//		Cache.RemoveDamage(Damage);
//	}
//
//}
