using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public static List<Creature> crystal = new List<Creature>();
	public static List<Creature> castles = new List<Creature>();
	bool plague;
	int empathy;
	void Update () 
	{

		if (castles[empathy].Turn && plague) return;
		if (plague) empathy++;
		if (empathy < castles.Count)
		{
			castles[empathy].Turn = true;
			castles[empathy].CleanUp();
			plague = true;
			return;
		}
		if (empathy == castles.Count)
		{
			empathy = 0;
			plague = false;
		}


		for (int i = crystal.Count - 1; i > -1; i--)
		{
			crystal[i].Dead();
		}

		for (int i = crystal.Count - 1; i > -1; i--)
		{
			crystal[i].Turn = true;
			crystal[i].CleanUp();
			crystal[i].AI ();
		}
			
	}
}