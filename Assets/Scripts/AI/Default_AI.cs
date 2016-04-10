using UnityEngine;
using System.Collections;

public class Default_AI : Creature_AI 
{
	protected override void Begin ()
	{
		base.Begin ();
		CurrentState = State.End;
	}
}
