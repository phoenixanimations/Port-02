//using UnityEngine;
//using System.Collections;
//
//public class AddDamage : StatusFoundation
//{
//	public bool OnceOnly = true;
//
//	protected override void Start ()
//	{
//		base.Start ();
//		Damage = 10;
//	}
//
//	protected override void Status ()
//	{
//		base.Status ();
//		if (OnceOnly)
//			Cache.AddDamage(Damage);
//		OnceOnly = false; 
//	}
//
//	public override void Deactivate ()
//	{
//		base.Deactivate ();
//		Cache.RemoveDamage(Damage);
//	}
//}