using UnityEngine;
using System.Collections;
using System_Control;

public class Defect_Foundation : Status_Foundation 
{
	public float Turn;
	public float Modify_Stat;

	public override void Beginning_Of_Turn ()
	{
		base.Beginning_Of_Turn ();
		Turn--;
	}

	public override void End_Of_Turn ()
	{
		base.End_Of_Turn ();
		if (Turn <= 0)
		{
			Creature.Defects.Remove(this);
		}
	}
}