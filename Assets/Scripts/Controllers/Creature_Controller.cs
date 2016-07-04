using UnityEngine;
using System.Collections;
using System_Control;

public class CreatureController : MonoBehaviour
{
	private Creature Creature;
	private MonoBehaviour[] CacheMonoBehaviour;
	
	private void Start ()
	{
		Creature = this.GetComponent<Creature>();
	}
	
	private void Update () 
	{
		if (Creature.Turn)
		{
			if(Input.GetKey (KeyCode.A))
			{
				ChangeFrontUpDownLeftRight ();
				return;
			}
			
			if (Input.GetKey (KeyCode.LeftShift))
			{
				ChangeFrontUpDownLeftRight ();
				return;
			}

			if (Input.GetKey (KeyCode.S))
			{
				ChangeFrontUpDownLeftRight ();
				return;
			}

			if (Input.GetKey (KeyCode.Space))
			{
				ChangeFrontUpDownLeftRight ();
				return;
			}
			
			if (Input.GetKeyUp(KeyCode.LeftShift)) Idle();
			if (Input.GetKeyUp(KeyCode.A)) UseWeapon ();
			if (Input.GetKeyUp(KeyCode.S)) Interact();
			if (Input.GetKeyUp(KeyCode.Space)) Jump();

			if(Input.GetKeyDown(KeyCode.UpArrow)) Attack(Vector.Up);
			if(Input.GetKeyDown(KeyCode.DownArrow)) Attack(Vector.Down);
			if(Input.GetKeyDown(KeyCode.LeftArrow)) Attack(Vector.Left);
			if(Input.GetKeyDown(KeyCode.RightArrow)) Attack(Vector.Right);			
		}
	}
	
	private void UseWeapon () 
	{
		Creature.Use ();
	}
	
	private void Attack (Vector2 Direction)
	{
		Creature.Move_Attack (Direction);
	}

	private void ChangeFront (Vector2 Direction) 
	{
		Creature.ModifyFront(Direction);
	}

	private void ChangeFrontUpDownLeftRight ()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow)) ChangeFront(Vector.Up);
		if(Input.GetKeyDown(KeyCode.DownArrow)) ChangeFront(Vector.Down);
		if(Input.GetKeyDown(KeyCode.LeftArrow)) ChangeFront(Vector.Left);
		if(Input.GetKeyDown(KeyCode.RightArrow)) ChangeFront(Vector.Right);
	}
	
	private void Jump()
	{
		Creature.Jumping();
	}
	
	private void Interact ()
	{
		Creature.Request_Interaction();
	}

	private void Idle ()
	{
		Creature.Idle();
	}
}

//Rewrite CreatureController to support cursor. 