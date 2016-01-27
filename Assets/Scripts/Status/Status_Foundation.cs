using UnityEngine;
using System.Collections;

public class Status_Foundation : Movement
{
	protected Creature Cache;
	protected override void Start ()
	{
		base.Start ();
		Cache = gameObject.GetComponent<Creature>();
		Cache.Beginning_Of_Turn += Beginning_Of_Turn;
		
//		Cache.Attack_Begin += Attack_Begin;
//		Cache.Attack_Miss += Attack_Miss;
//		Cache.Attack_End += Attack_End;
		
		Cache.End_Of_Turn += End_Of_Turn;
		
//		Cache.Enemy_Attack_Begin += Enemy_Attack_Begin;
//		Cache.Enemy_Attack_Miss += Enemy_Miss_Status;
//		Cache.Enemy_Attack_End += Enemy_End_Status;
	}

	protected virtual void Beginning_Of_Turn ()
	{
		ModifyFront(Cache.Front);
	}

	protected virtual void Attack_Begin () {}
	protected virtual void Attack_Miss() {}
	protected virtual void Attack_End () {}

	public virtual void Weapon_Passive_Attack_Begin (){}
	public virtual void Weapon_Passive_Attack_Miss (){}
	public virtual void Weapon_Passive_Attack_End (){}

	protected virtual void Enemy_Attack_Begin () {}
	protected virtual void Enemy_Miss_Status () {}
	protected virtual void Enemy_End_Status () {}

	protected virtual void End_Of_Turn (){}

	public virtual void Deactivate ()
	{
		Cache.Beginning_Of_Turn -= Beginning_Of_Turn;
			
//		Cache.Attack_Begin -= Attack_Begin;
//		Cache.Attack_Miss -= Attack_Miss;
//		Cache.Attack_End -= Attack_End;
//		
		Cache.End_Of_Turn -= End_Of_Turn;
		
//		Cache.Enemy_Attack_Begin -= Enemy_Attack_Begin;
//		Cache.Enemy_Attack_Miss -= Enemy_Miss_Status;
//		Cache.Enemy_Attack_End -= Enemy_End_Status;
		Destroy(this);
	}
}