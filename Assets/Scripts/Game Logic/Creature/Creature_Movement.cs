using UnityEngine;
using System.Collections;
using System_Control;

public class Creature_Movement : Creature_Stats
{
	public Vector2 Front {get;private set;}
	protected bool AllowMove;

	protected override void Start ()
	{
		base.Start ();
		Front = Vector.Right;
	}
	
	protected void AllowMovement(bool TrueOrFalse)
	{
		AllowMove = TrueOrFalse;
	}

	public virtual void Move (Vector2 Direction)
	{
		AllowMove = true;
		if (Raycast.SearchForCreature(Direction,Storey))
		{
			AllowMove = false;
		}

		if (AllowMove)
		{
			float x = transform.position.x + Direction.x;
			float y = transform.position.y + Direction.y;
			transform.position = new Vector2(Mathf.Round(x * 100f)/100f,Mathf.Round(y * 100f)/100f);
		}
	}
	
	public void ModifyFront (Vector2 Direction)
	{
		Front = Direction;
	}
}