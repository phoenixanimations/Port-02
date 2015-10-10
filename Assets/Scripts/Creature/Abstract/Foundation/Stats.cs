using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Stats : BasicTile
{
	public int Health;
	public int Damage;
	protected float Eye;
	protected float Ear;
	protected float Nose;

	protected List<int> ListHealth = new List<int>();
	protected List<int> ListDamage = new List<int>();
	
	protected int CalculateList (List<int> IntArray)
	{
		int Total = 0;
		for (int i = 0; i < IntArray.Count; i++) Total += IntArray[i];
		return Total;
	}

	public void AddDamage    (int DamageAmount)  {Damage += DamageAmount;}
	public void RemoveDamage (int DamageAmount)  {Damage -= DamageAmount;}
	public void AddHealth    (int HealthAmount)  {Health += HealthAmount;}
	public void RemoveHealth (int HealthAmount)  {Health -= HealthAmount;}
}