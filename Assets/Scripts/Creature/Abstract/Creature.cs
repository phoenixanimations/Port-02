using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Creature : Movement {

	public bool Turn;
	public bool Player;

	public int Health;
	public int Damage;
	protected List<int> ListHealth = new List<int>();
	protected List<int> ListDamage = new List<int>();

	public delegate void DelegateStatus ();
	public event DelegateStatus AddStatus = delegate {}; 
	
	protected Type Weapon, Helmet, Chest, Legs, DNA;
//	protected List<Item> Inventory = new List<Item>();
//	protected List<Status> AddStatus = new List<Status>();
//	public delegate event AddStatus AddStatus;


	private RaycastHit2D RightHit, LeftHit, UpHit, DownHit;


	protected override void Update ()
	{
		base.Update ();
	}


	protected override void Start () 
	{
		base.Start();
		Physics2D.raycastsStartInColliders = false;
		GameManager.creature.Add(this);
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

	public virtual void AI ()
	{
		if (Player) return;
		Move("Left");
		Turn = false;
	}

	public virtual void Use () 
	{
		ActivateRaycast();

//		Weapon.Test(this.gameObject);
	//	gameObject.AddComponent(Weapon.Ability);
//		Debug.Log(LeftHit.collider);
//		Debug.Log(Physics2D.RaycastAll(transform.position,transform.right,20f).Length);
		RightHit.collider.GetComponent<Creature>().Move("Right");
		RightHit.collider.GetComponent<Creature>().Move("Right");
		RightHit.collider.GetComponent<Creature>().Move("Right");
		RightHit.collider.GetComponent<Creature>().Move("Right");
		RightHit.collider.GetComponent<Creature>().Move("Right");
		RightHit.collider.GetComponent<Creature>().Move("Right");
		RightHit.collider.GetComponent<Creature>().Move("Right");
//		RightHit.collider.GetComponent<Creature>().Move("Right");


//		UpHit.collider.GetComponent<Movement>().Move("Up");
//		DownHit.collider.GetComponent<Movement>().Move("Down");
//		RightHit.collider.GetComponent<Movement>().Move("Right");


//		LeftHit.collider.GetComponent<Movement>().Move("Left");
//		UpHit.collider.GetComponent<Movement>().Move("Up");
//		DownHit.collider.GetComponent<Movement>().Move("Down");
//
//		LeftHit.collider.GetComponent<Movement>().Move("Left");
//		UpHit.collider.GetComponent<Movement>().Move("Up");
//		DownHit.collider.GetComponent<Movement>().Move("Down");

//		Debug.Log (LeftHit.collider);

	//	Invoke(Weapon.Use,0);												
	}

	public void Equip (Type Equipment) 
	{
		gameObject.AddComponent(Equipment);
	}

	public void UnEquip () 
	{

	}

	private void ActivateStatus () 
	{
		AddStatus();
	}

	public void CleanUp ()
	{
		ActivateStatus();
		Health = CalculateList(ListHealth);
		Damage = CalculateList(ListDamage);
	}

	private int CalculateList (List<int> IntArray)
	{
		int Total = 0;
		for (int i = 0; i < IntArray.Count; i++)
		Total += IntArray[i];
		return Total;
	}



	public void AddDamage (int DamageAmount)
	{
		ListDamage.Add(DamageAmount);
	}

	public int AddDamage ()
	{
		return ListDamage.Count;
	}

	public void AddDamage (int ListLocation, int DamageAmount)
	{
		ListDamage[ListLocation] = DamageAmount;
	}


	public void AddHealth (int HealthAmount)
	{
		ListHealth.Add(HealthAmount);
	}



	private void ActivateRaycast () 
	{
		RightHit = Physics2D.Raycast(transform.position,transform.right, x);  
		LeftHit = Physics2D.Raycast(transform.position,-transform.right, x); 
		UpHit = Physics2D.Raycast(transform.position,transform.up, y);  
		DownHit = Physics2D.Raycast(transform.position,-transform.up, y);
	}


}
