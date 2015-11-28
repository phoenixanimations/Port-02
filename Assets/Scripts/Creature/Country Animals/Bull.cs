using UnityEngine;
using System.Collections;

public class Bull : Creature {

//	Vector3 RemeberPosition;
	GameObject TackleCreature;




	protected override void Start ()
	{
		base.Start ();
		Hitpoints = 3;
		Damage = 1;
		gameObject.AddComponent(typeof(WalkAddDamage));
	}

	public override void AI ()
	{
		base.AI ();
//		FindTarget();
//
//		if(TackleTarget(Vector3.up)) return;
//		if(TackleTarget(Vector3.down)) return;
//		if(TackleTarget(Vector3.left)) return;
//		if(TackleTarget(Vector3.right)) return;
//		if(TackleTarget(Vector3.up + Vector3.left)) return;
//		if(TackleTarget(Vector3.up + Vector3.right)) return;
//		if(TackleTarget(Vector3.down + Vector3.left)) return;
//		if(TackleTarget(Vector3.down + Vector3.right)) return;

		Idle ();
	}

	//Have him standing somewhere waiting. If he sees you he starts to run after you. 

//	public void FindTarget ()
//	{
//		if (TackleCreature) return;
//
//		Hit = Physics2D.Raycast(transform.position,Front,Eye);
//		if (Hit.collider != null)
//		{
//			TackleCreature = Hit.collider.gameObject;
//			return;
//		}
//		TackleCreature = null;
//	
//	}
//
//	public bool TackleTarget (Vector3 Direction)
//	{
//		if (TackleCreature == null) return false;
//		Hit = Physics2D.Raycast(transform.position,Direction,Eye);
//		if (Hit.collider != null && Hit.collider.name == TackleCreature.name)
//		{
//			MoveAttack(Direction);
//			return true;
//		}
//
//		return false;
//	}

}
