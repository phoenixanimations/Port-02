using UnityEngine;
using System.Collections;
using System;
using System_Control;

public class Vehicle : Creature 
{

	protected GameObject RememberCreature;
	protected Creature CacheCreature;

	protected override void Start ()
	{
		base.Start ();
		Get_Stat(Stat.Hitpoints,2f,true);
		CreatureType = "Vehicle";
	}

	public void VehicleMessage (GameObject creature)
	{
		creature.transform.position = transform.position;
		creature.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		creature.gameObject.GetComponent<CircleCollider2D>().enabled = false;
		creature.GetComponent<Creature>().Idle();
		creature.GetComponent<Creature>().ModifyState(false);
		RememberCreature = creature;
		CacheCreature = RememberCreature.GetComponent<Creature>();
	}

	public override void Move (Vector3 Direction)
	{
		base.Move (Direction);
		if (RememberCreature != null)
		RememberCreature.transform.position = transform.position;
	}

	public override void AI ()
	{
		base.AI ();
		if (RememberCreature == null) return;

		State = CacheCreature.State;
		ModifyFront(CacheCreature.Front);

		switch (State)
		{
			case "Use":
			Debug.Log ("Use");
			break;

			case "MoveAttack":
			Move_Attack(CacheCreature.Front);
			break;

			case "VehicleRequest":
			DisableDirection(Vector3.up);
			DisableDirection(Vector3.down);
			DisableDirection(Vector3.left);
			DisableDirection(Vector3.right);
			break;

			case "Idle":
			break;

			default:
			Debug.LogError("Wrong State, what went wrong?");
			break;
		}
	}

	private void DisableDirection (Vector3 Direction)
	{
		if (RememberCreature == null || CacheCreature == null) return;
		Hit = Physics2D.Raycast(transform.position,Direction,x);
		if (Hit.collider == null)
		{
			CacheCreature.transform.position += Vector3.Scale(new Vector3(x,y,0), Direction);
			RememberCreature.GetComponent<SpriteRenderer>().enabled = true;
			RememberCreature.GetComponent<CircleCollider2D>().enabled = true;
			CacheCreature.ModifyState(true);
			CacheCreature.Idle();
			RememberCreature = null;
			CacheCreature = null;
		}
	}
}