using UnityEngine;
using System.Collections;

public class Movement : Stats
{
	public Vector3 Front {get;private set;}
	private bool AllowMove;

	public override void Assign_Stats ()
	{
		base.Assign_Stats ();
		Front = transform.right;
	}

	protected void AllowMovement(bool TrueOrFalse)
	{
		AllowMove = TrueOrFalse;
	}

	public virtual void Move (Vector3 Direction)
	{
		if (AllowMove)
		{
			transform.position += (Vector3.Scale(new Vector3 (x,y,0), Direction));
		}
	}
	
	public void ModifyFront (Vector3 Direction)
	{
		Front = Direction;
	}
}