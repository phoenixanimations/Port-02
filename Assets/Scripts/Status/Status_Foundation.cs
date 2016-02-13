using UnityEngine;
using System.Collections;
using System_Control;

public class Status_Foundation : Movement
{	
	protected Creature Creature;
	protected Attack Creature_Attack;
	protected Equipment_Foundation Creature_Equipment;
	protected bool Activate_Once;
	
	protected override void Start (){}

	public void Assign_Status (GameObject Equipped_Creature)
	{
		Physics2D.queriesStartInColliders = false;
		Creature = Equipped_Creature.GetComponent<Creature>();
		Creature_Attack = Equipped_Creature.GetComponent<Attack>();
		Creature_Equipment = this.GetComponent<Equipment_Foundation>();
	}

	public virtual void Beginning_Of_Turn () 
	{
		Activate_Once = true;
	}
	public virtual void Attack_Status (Phase Activate_On_What_Phase) {}

	public virtual void Counter_Attack_Status (Phase Activate_On_What_Phase,Creature Advisory, Attack Advisory_Attack) {}

	public virtual void End_Of_Turn () {}
	
	public virtual void Terminate_Status ()
	{
		Creature = null;
		Destroy(this);
	}
}
