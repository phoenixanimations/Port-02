using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public static List<Creature> crystal = new List<Creature>();
	public static List<Creature> castles = new List<Creature>();

	public List<Creature> Player = new List<Creature>();
	public List<Creature> AI = new List<Creature>();

	bool Plague = true;
	int empathy;
	int vietnam;

	void Update () 
	{
		AI = crystal;
		Player = castles;


		if (vietnam == 0) {castles[empathy].Status();}
		if (vietnam == 1 && castles[empathy].Turn) return;
		if (vietnam == 2) {castles[empathy].CleanUpStatus();}
		vietnam++;
		if (vietnam < 3) return;
		empathy++;
		if (vietnam == 3 && empathy < castles.Count)
		{
			castles[empathy].Turn = true;
			vietnam = 0;
			return;
		}		
		for (int i = castles.Count - 1; i > -1; i--)
		{
			castles[i].Dead();
		}

		for (int i = crystal.Count - 1; i > -1; i--)
		{
			crystal[i].Dead();
		}

		for (int i = crystal.Count - 1; i > -1; i--)
		{
			crystal[i].Turn = true;
			crystal[i].Status();
			crystal[i].AI();
			crystal[i].CleanUpStatus();
		}	


		empathy = 0;
		vietnam = 0;
		castles[empathy].Turn = true;

		OrganizeVehicles(); //Delete.
	}

	void OrganizeVehicles ()
	{
		if (Plague)
		{
			Creature RememberMe;
			for (int i = crystal.Count - 1; i > -1; i--)
			{
				RememberMe = crystal[i];
				if (crystal[i].Type == "Vehicle")
				{
					crystal.RemoveAt(i);
					crystal.Insert(0,RememberMe);
				}
			}
		}
		Plague = false;
	}
}