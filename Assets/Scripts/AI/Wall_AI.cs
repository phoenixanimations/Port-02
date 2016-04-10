using UnityEngine;
using System.Collections;

public class Wall_AI : Creature_AI 
{
	protected override void Begin ()
	{
		base.Begin ();
		if (Random.Range(-500000,10000) > 9990)
			gameObject.GetComponent<Creature>().Move(Vector2.right);
		if (Random.Range(-500000,10000) > 9000)
			gameObject.GetComponent<Creature>().Move(Vector2.up);
		if (Random.Range(-500000,10000) > 9500)
			gameObject.GetComponent<Creature>().Move(Vector2.left);
		if (Random.Range(-500000,10000) > 9700)
			gameObject.GetComponent<Creature>().Move(Vector2.down);
		CurrentState = State.End;
	}
}
