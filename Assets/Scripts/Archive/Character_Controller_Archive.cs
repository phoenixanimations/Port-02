using UnityEngine;
using System.Collections;
using System;


public class Character_Controller_Archive : MonoBehaviour
{
	private Creature Cache;

	public delegate void Delegate();

	public event Delegate State = delegate {};



	public void ActivateState ()
	{
		State();
	}

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
				if(Input.GetKeyDown(KeyCode.UpArrow)) State += FrontUp;
				if(Input.GetKeyDown(KeyCode.DownArrow)) State += FrontDown;
				if(Input.GetKeyDown(KeyCode.LeftArrow)) State += FrontLeft;
				if(Input.GetKeyDown(KeyCode.RightArrow)) State += FrontRight;
				return;
			}

			if (Input.GetKeyUp (KeyCode.A)) State += UseWeapon;
			if (Input.GetKeyDown (KeyCode.S)) State += UseVehicle;
			if(Input.GetKeyDown(KeyCode.UpArrow)) State += MoveUp;
			if(Input.GetKeyDown(KeyCode.DownArrow)) State += MoveDown;
			if(Input.GetKeyDown(KeyCode.LeftArrow)) State += MoveLeft;
			if(Input.GetKeyDown(KeyCode.RightArrow)) State += MoveRight;
			if(Input.GetKeyDown(KeyCode.Space)) State += Idle;

			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown (KeyCode.Space))
			Cache.Turn = false;
		}
	}

	private void FrontUp ()
	{
		Cache.ModifyFront(Vector3.up);
		State -= FrontUp;
	}

	private void FrontDown ()
	{
		Cache.ModifyFront(Vector3.down);
		State -= FrontDown;
	}

	private void FrontLeft ()
	{
		Cache.ModifyFront(Vector3.left);
		State -= FrontLeft;
	}

	private void FrontRight ()
	{
		Cache.ModifyFront(Vector3.right);
		State -= FrontRight;
	}

	private void UseWeapon () 
	{
		Cache.Use ();
		State -= UseWeapon;
	}

	private void UseVehicle ()
	{
		Cache.VehicleRequest();
		State -= UseVehicle;
	}

	private void MoveUp ()
	{
		Cache.MoveAttack(Vector3.up);
		State -= MoveUp;
	}

	private void MoveDown ()
	{
		Cache.MoveAttack(Vector3.down);
		State -= MoveDown;
	}

	private void MoveLeft ()
	{
		Cache.MoveAttack(Vector3.left);
		State -= MoveLeft;
	}

	private void MoveRight ()
	{
		Cache.MoveAttack(Vector3.right);
		State -= MoveRight;
	}

	private void Idle ()
	{
		Cache.Idle();
		State -= Idle;
	}
}
