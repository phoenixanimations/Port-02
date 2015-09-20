using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static List<Creature> creature = new List<Creature>();
	public List<Creature> meh = new List<Creature>();
	//public static int hmm;
	// Use this for initialization


	void Start () 
	{

		//Debug.Log (creature.Count);
		//Debug.Log ("Second: " + this);

	}
	
	// Update is called once per frame
//	private int i;

	int i;
	void Update () 
	{
//		meh = creature;
//		Debug.Log (creature.Count);


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





//		if (creature[i].Player)
//		{
//		Debug.Log ("hi");
//		return;
//		}
//
//		for (i = 0; i < creature.Count; i++)
//		{
//			Debug.Log (creature[i]);
//		}

//		for (i = 0; i < Creature.Count; i++)
//		{
//
//			Creature[i].Turn = true;
//
//			if (!Creature[i].Player)
//			{
//			Creature[i].AI();
//			}
//
//
//			Debug.Log (Creature[i].Turn);
//		}
//		for (int i, i < Creature.Count;)
//		Creature.Count;



	
	}
}
