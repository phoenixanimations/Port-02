using UnityEngine;
using System.Collections;

public class Creature_AI : MonoBehaviour 
{
	private int CatchInfinityLoop;
	protected enum State {Begin, Idle, Equip, Move, Use, Examine, End}
	protected State CurrentState = State.Begin;

	public virtual void StateMachine ()
	{
		CatchInfinityLoop = 0;
		while (CurrentState != State.End)
		{
			CatchInfinityLoop++;
			if (CatchInfinityLoop == 100){ Debug.LogError("While loop mess up"); break;}
			switch (CurrentState)
			{
				case State.Begin:   Begin();   break;
				case State.Idle:    Idle();    break;
				case State.Equip:   Equip();   break;
				case State.Move:    Move();    break;
				case State.Use:     Use();     break;
				case State.Examine: Examine(); break;
				case State.End:     End();     break;
				default: Debug.LogError ("ERROR STATE NOT FOUND"); break;
			}
		}
		CurrentState = State.Begin;	
	}
	protected virtual void Begin () 
	{


	}
	
	protected virtual void Idle ()
	{

	}

	protected virtual void Equip ()
	{

	}

	protected virtual void Move ()
	{

	}

	protected virtual void Use ()
	{
	
	}
	
	protected virtual void Examine ()
	{

	}

	protected virtual void End ()
	{

	}
}
