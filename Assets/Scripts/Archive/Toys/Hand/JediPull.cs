//using UnityEngine;
//using System.Collections;
//
//public class JediPull : ItemFoundation
//{
//	public float Distance = 2f;
//
//	protected override void Initiate ()
//	{
//		base.Initiate ();
//		Damage = 1;
//		Name = "Jedi Pull";
//	}
//
//	protected override void Use ()
//	{
//		base.Use ();
//		HitArray = Physics2D.RaycastAll(transform.position,Front,Distance);
//		if (HitArray.Length > 0)
//		{
//			for (int i = 0; i < HitArray.Length; i++)
//			{
//				HitArray[i].collider.GetComponent<Creature>().Move(-Front);
//			}
//		}
//	}
//
//
//}
