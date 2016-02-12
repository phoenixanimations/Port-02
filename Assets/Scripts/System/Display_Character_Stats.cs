using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Display_Character_Stats : MonoBehaviour 
{
	private Creature Creature;
	private Attack Creature_Attack;
	private float Hitpoints;
	private float Energy;

	protected void Start ()
	{
		Creature = GetComponent<Creature>();
		Creature_Attack = GetComponent<Attack>();
	}

	protected void Update ()
	{	
		Hitpoints = Creature.Get_Stat(Stat.Hitpoints);
		






		Energy = Creature.Get_Stat(Stat.Energy);
	}
}




















/*
	[Header("Hitpoints")]

	[Header("Class Damage")]

	[Header("Critical Damage")]

	[Header("Accuracy Damage")]

	[Header("Class Resistance")]
*/