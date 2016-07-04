using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System_Control;

public class Raycast_Find_Creature : Raycast_Simple 
{
	/********************************************
	 ********Search for 1 Creature***************
	 ********************************************/
	private bool SearchForCreature(Vector2 Position, Vector2 Direction, float Distance, float Storey) 
	{
		Direction *= .5f;
		Hit = Physics2D.Raycast(Position,Direction,Distance,(int)Mask.Default);
		if (Hit.collider != null) 
		{
			TargetCreature = Hit.collider.GetComponent<Creature_States>();
			if (Storey == TargetCreature.Storey) return true;
		}

		TargetCreature = null;
		return false;
	}

	public bool SearchForCreature(Vector2 Direction, float LengthTimesAmount, float Storey) 
	{
		return SearchForCreature(Position(),Direction,Length * LengthTimesAmount,Storey);
	}

	public bool SearchForCreature(Vector2 Direction, float Storey)
	{
		return SearchForCreature(Position(),Direction,Length,Storey);
	}

	/*********************************************
	 *Search for Creatures in Multiple Directions*
	 *********************************************/
	
	private bool SearchForMultipleDirections (Vector2 Position,Vector2[] Directions, float Distance, float Storey)
	{
		TargetMultipleCreature.Clear();
		if (Directions.Length < 2)
		{
			Debug.LogError("There has to be at least two directions");
		}
		for (int iDirection = 0; iDirection < Directions.Length; iDirection++) 
		{
			if (SearchForCreature(Position,Directions[iDirection],Distance,Storey))
			{
				TargetMultipleCreature.Add(TargetCreature);
			}
		}
		if (TargetMultipleCreature.Count > 0)
		{
			return true;
		}
		return false;
	}

	public bool SearchForMultipleDirections (Vector2[] Directions, float Distance, float Storey)
	{
		return SearchForMultipleDirections(Position(),Directions,Distance, Storey);
	}

	public bool SearchForMultipleDirections (Vector2[] Directions, float Storey)
	{
		return SearchForMultipleDirections(Position(),Directions,Length, Storey);
	}

	/********************************************
	 ******Search for Multiple Creatures*********
	 ********************************************/
	private bool SearchForMultipleCreatures (Vector2 Position, Vector2 Direction, float Distance, float Storey)
	{
		Direction *= .5f;
		TargetMultipleCreature.Clear();
		HitArray = Physics2D.RaycastAll(Position, Direction, Distance,(int)Mask.Default);
		if (HitArray.Length > 0)
		{
			TargetMultipleCreature = HitArray.Where(c => c.collider.GetComponent<Creature_States>().Storey == Storey)
											 .Select(c => c.collider.GetComponent<Creature_States>())
											 .OrderByDescending(p => p.transform.position.y)
											 .ThenBy(p => p.transform.position.x).ToList();
			return true;
		}
		return false;
	}	

	public bool SearchForMultipleCreatures (Vector2 Direction, float LengthTimesAmount, float Storey)
	{
		return SearchForMultipleCreatures (Position(), Direction,Length * LengthTimesAmount, Storey);
	}

	/********************************************
	 ********************Physics*****************
	 ********************************************/
	//Add support for Vector2 Vector2UpDownLeftRight and Distance other than infinity
	public bool SearchForHeight (Vector2 AddToPosition, bool HitStartCollider)
	{
		TargetMultipleCreature.Clear();
		if (HitStartCollider)
		{
			Vector2 OffSetRaycast = new Vector2 (0f,-.07f);
			HitArray = Physics2D.RaycastAll(Position() + AddToPosition + OffSetRaycast,Vector2.up,Mathf.Infinity,(int)Mask.Default);
		}
		else
		{
			HitArray = Physics2D.RaycastAll(Position() + AddToPosition,Vector2.up,Mathf.Infinity,(int)Mask.Default);
		}
		if (HitArray.Length > 0)
		{
			TargetMultipleCreature.AddRange(HitArray.Select(c => c.collider.GetComponent<Creature_States>()));
			return true;
		}
		else
		{
			return false;
		}
	}
}