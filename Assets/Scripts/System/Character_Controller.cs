using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour
{
	private Creature Cache;
	private MonoBehaviour[] CacheMonoBehaviour;
	
	private void Start ()
	{
		Cache = this.GetComponent<Creature>();
	}
	
	private void Update () 
	{
		if (Cache.Turn)
		{
			if(Input.GetKey (KeyCode.A))
			{
				if(Input.GetKeyDown(KeyCode.UpArrow)) ChangeFront(Vector3.up);
				if(Input.GetKeyDown(KeyCode.DownArrow)) ChangeFront(Vector3.down);
				if(Input.GetKeyDown(KeyCode.LeftArrow)) ChangeFront(Vector3.left);
				if(Input.GetKeyDown(KeyCode.RightArrow)) ChangeFront(Vector3.right);
				return;
			}

			if (Input.GetKeyUp (KeyCode.A)) UseWeapon ();
			if (Input.GetKeyDown (KeyCode.S)) UseVehicle();
			if (Input.GetKeyDown (KeyCode.Space)) Idle ();
			if(Input.GetKeyDown(KeyCode.UpArrow)) Attack(Vector3.up);
			if(Input.GetKeyDown(KeyCode.DownArrow)) Attack(Vector3.down);
			if(Input.GetKeyDown(KeyCode.LeftArrow)) Attack(Vector3.left);
			if(Input.GetKeyDown(KeyCode.RightArrow)) Attack(Vector3.right);
			
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown (KeyCode.Space))
				Cache.Turn = false;
		}
	}
	
	private void UseWeapon () 
	{
		Cache.Use ();
	}
	
	private void Attack (Vector3 Direction)
	{
		Cache.MoveAttack (Direction);
	}
	
	private void ChangeFront (Vector3 Direction) 
	{
		Cache.ModifyFront(Direction);
	}
	
	private void UseVehicle ()
	{
		Cache.VehicleRequest();
	}

	private void Idle ()
	{
		Cache.Idle();
	}
	
}