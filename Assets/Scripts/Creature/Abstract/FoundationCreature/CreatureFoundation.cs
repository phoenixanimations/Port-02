using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System_Control;

public class CreatureFoundation : Movement
{
	[HideInInspector]
	public bool Turn;
	public bool Player;
	[HideInInspector]
	public string CreatureType, State;
	public GameObject Equip_Primary_Weapon;
	public GameObject Equip_Secondary_Weapon;
	public GameObject Equip_Helmet;
	public GameObject Equip_Chest;
	public GameObject Equip_Legs;
	[HideInInspector]
	public Weapon_Foundation Primary_Weapon, Secondary_Weapon;
	[HideInInspector]
	public Equipment_Foundation Helmet, Chest, Legs;
	protected Attack Attack_Cache;

	public delegate void Delegate ();

	protected bool EnableState;	

	protected override void Start ()
	{
		base.Start ();
		gameObject.AddComponent<Attack>().hideFlags = HideFlags.HideInInspector;
		Attack_Cache = GetComponent<Attack>();
		if (Equip_Primary_Weapon != null) 	Primary_Weapon   = Equip_Primary_Weapon.GetComponent<Weapon_Foundation>();
		if (Equip_Secondary_Weapon != null) Secondary_Weapon = Equip_Secondary_Weapon.GetComponent<Weapon_Foundation>();
		if (Equip_Chest != null)  			Helmet 			 = Equip_Helmet.GetComponent<Equipment_Foundation>();
		if (Equip_Helmet != null) 			Chest 		     = Equip_Chest.GetComponent<Equipment_Foundation>();
		if (Equip_Legs != null)   			Legs 	  	 	 = Equip_Legs.GetComponent<Equipment_Foundation>();
	}
}