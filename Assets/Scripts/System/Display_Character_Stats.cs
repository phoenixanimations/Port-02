using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Display_Character_Stats : MonoBehaviour 
{

	private Creature Cache;
	[Header("Hitpoints")]
	public float Hitpoints;
	[Header("Class Damage")]
	public float Primary_Damage;
	public float Secondary_Damage;
	[Header("Critical Damage")]
	public float Critical_Chance;
	public float Critical_Damage;
	[Header("Accuracy Damage")]
	public float Primary_Accuracy;
	public float Secondary_Accuracy;
	[Header("Class Resistance")]
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
		Critical_Chance = Cache.Get_Stat(Stat.Critical_Chance);
		Critical_Damage = Cache.Get_Stat(Stat.Critical_Damage);

		Melee_Resistance = Cache.Get_Stat(Stat.Melee_Resistance);
		Magic_Resistance = Cache.Get_Stat(Stat.Magic_Resistance);
		Archery_Resistance = Cache.Get_Stat(Stat.Archery_Resistance);
	}
}