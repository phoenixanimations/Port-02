using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Display_Character_Stats : MonoBehaviour 
{
	private Creature Cache;
	public float Hitpoints;
	public float Primary_Damage;
	public float Secondary_Damage;

	public float Primary_Accuracy;
	public float Secondary_Accuracy;
	public float Melee_Resistance;
	public float Magic_Resistance;
	public float Archery_Resistance;

	protected void Start ()
	{
		Cache = GetComponent<Creature>();
	}

	protected void Update ()
	{	
		Hitpoints = Cache.Get_Stat(Stat.Hitpoints);	
		
	}
}




















/*
	[Header("Hitpoints")]

	[Header("Class Damage")]

	[Header("Critical Damage")]

	[Header("Accuracy Damage")]

	[Header("Class Resistance")]




*/