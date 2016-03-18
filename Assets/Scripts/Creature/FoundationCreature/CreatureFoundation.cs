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
	public GameObject Equip_Armor;
	[HideInInspector]
	public Equipment_Foundation Primary_Weapon, Secondary_Weapon;
	[HideInInspector]
	public Equipment_Foundation Armor;
	protected Attack Attack_Cache;
	public List<Defect_Foundation> Defects = new List<Defect_Foundation>();
	public List<Active_Foundation> Actives = new List<Active_Foundation>();

	public delegate void Delegate ();

	protected bool EnableState;	

	protected override void Start ()
	{
		base.Start ();
		gameObject.AddComponent<Attack>().hideFlags = HideFlags.HideInInspector;
		Attack_Cache = GetComponent<Attack>();
	}
		
	public override void Assign_Stats ()
	{
		base.Assign_Stats ();
		if (Equip_Primary_Weapon != null) 	Primary_Weapon   = Equip_Primary_Weapon.GetComponent<Equipment_Foundation>();
		if (Equip_Secondary_Weapon != null) Secondary_Weapon = Equip_Secondary_Weapon.GetComponent<Equipment_Foundation>();
		if (Equip_Armor != null)  			Armor 			 = Equip_Armor.GetComponent<Equipment_Foundation>();

	}
}