using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Creature : Movement 
{
	public delegate void Delegate ();
	public event Delegate AddStatus = delegate {};
	public event Delegate AddUse = delegate {};
	public bool Turn;
	public bool Player; 
	protected Type Weapon, Helmet, Chest, Legs, DNA;
	protected List<Type> Inventory = new List<Type>();
	private RaycastHit2D RightHit, LeftHit, UpHit, DownHit;

	private void ActivateRaycast () 
	{
		RightHit = Physics2D.Raycast(transform.position,transform.right, x);  
		LeftHit = Physics2D.Raycast(transform.position,-transform.right, x); 
		UpHit = Physics2D.Raycast(transform.position,transform.up, y);  
		DownHit = Physics2D.Raycast(transform.position,-transform.up, y);
	}
	
	public void Dead ()
	{
		if (Health < 1) 
		{
			if (!Player) GameManager.crystal.Remove(this);
			if (Player) GameManager.castles.Remove (this);
			Destroy (this.gameObject);
		}
	}

	private void ActivateStatus () 
	{
		AddStatus();
	}

	protected override void Start () 
	{
		base.Start();
		Physics2D.raycastsStartInColliders = false;
		if (!Player) GameManager.crystal.Add(this);
		if (Player) GameManager.castles.Add (this);
		if (Player) gameObject.AddComponent<Character_Controller>();
	}

	public override void Move(string Direction)
	{
		AllowMovement();
		ActivateRaycast();
		
		if (RightHit) Stop("Right");
		if (LeftHit) Stop ("Left");
		if (DownHit) Stop ("Down");
		if (UpHit) Stop ("Up");
		
		base.Move(Direction);
	}
	
	public void CleanUp ()
	{
		ActivateStatus();
	}

	public virtual void AI ()
	{
		if (Player) return;
		Move("Left");
		Turn = false;
	}

	public void Use () 
	{
		AddUse();												
	}

	public void Attack (Vector3 Direction) 
	{
		Hit = Physics2D.Raycast(transform.position, Direction, x);
		if (Hit.collider != null) Hit.collider.GetComponent<Creature>().RemoveHealth(Damage);
	}

	public void Equip (Type Equipment) 
	{
		gameObject.AddComponent(Equipment);
	}

	public void UnEquip () 
	{
	
	}
}