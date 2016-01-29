using UnityEngine;
using System.Collections;
using System_Control;

public class Status_Foundation : Movement
{	
	protected Creature Cache;
	
	protected override void Start (){}

	public override void Assign_Stats ()
	{
		base.Assign_Stats ();
		if (gameObject.GetComponent<Creature>() == null)
		{
			Debug.LogError("Attach Status to a Creature!");
			return;
		}
		Cache = gameObject.GetComponent<Creature>();
	}

	public virtual void Beginning_Of_Turn () { ModifyFront(Cache.Front); Debug.Log("hi"); }
	public virtual void Attack_Status (Phase Activate_On_What_Phase) {}
	public virtual void End_Of_Turn () {}
	
	public virtual void Terminate_Stats ()
	{

		Destroy(this);
	}
}