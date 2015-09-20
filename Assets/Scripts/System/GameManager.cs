using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static List<Creature> creature = new List<Creature>();
	public List<Creature> ListofCreatures = new List<Creature>();

	private int i;

	void Update () 
	{
		if (creature[i].Player && creature[i].Turn) return;
		while (i < creature.Count)
		{
			i++;
			if (i == creature.Count) i = 0;
			creature[i].Turn = true;
			creature[i].CleanUp();
			creature[i].AI ();
			if (creature[i].Player) break;	
		}
	}
}
