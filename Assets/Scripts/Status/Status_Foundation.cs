using UnityEngine;
using System.Collections;
using System_Control;

public class Status_Foundation : Movement
{	
	protected Creature Creature;
	protected Attack Creature_Attack;
	
	protected override void Start (){}

	public void Assign_Status (GameObject Equipped_Creature)
	{
		Physics2D.queriesStartInColliders = false;
		Creature = Equipped_Creature.GetComponent<Creature>();
		Creature_Attack = Equipped_Creature.GetComponent<Attack>();
	}

	public virtual void Beginning_Of_Turn () {}
	public virtual void Attack_Status (Phase Activate_On_What_Phase) {}
	public virtual void End_Of_Turn () {}
	
	public virtual void Terminate_Status ()
	{
		Creature = null;
		Destroy(this);
	}
}