using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Raycast_Stats : Basic_Tile 
{
	public float x;
	public float y = -1;
	public float Length = 2f;

	protected RaycastHit2D Hit;
	protected RaycastHit2D[] HitArray;

	public Creature_States TargetCreature;
	public List<Creature_States> TargetMultipleCreature;

	protected CircleCollider2D Collider;
}
