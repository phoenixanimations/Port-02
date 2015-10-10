using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CreatureFoundation : Movement
{
	public bool Player;
	public bool Turn;
	public string Type;
	public string State;
	public delegate void Delegate ();
	protected List<Type> Inventory = new List<Type>();
	protected Type Weapon;
	protected Type Helmet;
	protected Type Chest;
	protected Type Legs;
	protected Type DNA;
	protected bool EnableState;
}