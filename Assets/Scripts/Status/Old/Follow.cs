//using UnityEngine;
//using System.Collections;
//
//public class Follow : StatusFoundation
//{
//	//Front might be glitchy. Check it out. Change follow to drag have follow polymorph drag.  
//	public string hitName;
//	private bool Loop;
//
//	protected override void Status ()
//	{
//		base.Status ();
//		RaycastFollow(Vector3.up);
//		RaycastFollow(Vector3.down);
//		RaycastFollow(Vector3.left);
//		RaycastFollow(Vector3.right);
//		UpRight();
//		UpLeft();
//		DownLeft();
//		DownRight();
//	} 
//
//	private void RaycastFollow (Vector3 Direction)
//	{
//			Hit = Physics2D.Raycast(transform.position,Direction,x * 2f);
//			if (Hit.collider != null && Hit.collider.name == hitName)
//			{
//				Cache.Move(Direction);
//				Cache.ModifyFront(Direction);
//			}
//	}
//
//	private void UpRight ()
//	{
//		Hit = Physics2D.Raycast(transform.position,Vector3.up + Vector3.right,x * 2f);
//		if (Hit.collider != null && Hit.collider.name == hitName)
//		{
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.up) {Cache.Move(Vector3.right);Cache.ModifyFront(Vector3.right);}
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.right) {Cache.Move(Vector3.up);Cache.ModifyFront(Vector3.up);}
//		}
//	}
//
//	private void UpLeft ()
//	{
//		Hit = Physics2D.Raycast(transform.position,Vector3.up + Vector3.left,x * 2f);
//		if (Hit.collider != null && Hit.collider.name == hitName)
//		{
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.up) {Cache.Move(Vector3.left);Cache.ModifyFront(Vector3.left);}
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.left) {Cache.Move(Vector3.up);Cache.ModifyFront(Vector3.up);}
//		}
//	}
//
//	private void DownRight ()
//	{
//		Hit = Physics2D.Raycast(transform.position,Vector3.down + Vector3.right,x * 2f);
//		if (Hit.collider != null && Hit.collider.name == hitName)
//		{
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.down) {Cache.Move(Vector3.right);Cache.ModifyFront(Vector3.right);}
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.right) {Cache.Move(Vector3.down);Cache.ModifyFront(Vector3.down);}
//		}	
//	}
//
//	private void DownLeft ()
//	{
//		Hit = Physics2D.Raycast(transform.position,Vector3.down + Vector3.left,x * 2f);
//		if (Hit.collider != null && Hit.collider.name == hitName)
//		{
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.down) {Cache.Move(Vector3.left);Cache.ModifyFront(Vector3.left);}
//			if (Hit.collider.GetComponent<Creature>().Front == Vector3.left) {Cache.Move(Vector3.down);Cache.ModifyFront(Vector3.down);}
//		}		
//	}
//}
