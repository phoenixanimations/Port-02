using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System_Control;

/*
 * Here's the logic for the current game this is pretending that you have just pressed play:
 * In Start() it sends out a huge circle collider (with a radius of 200f) in the center of the screen.
 * This collider grabs everything on the scene and adds it to the Creatures list. 
 * Then it puts all Creatures in which Creature.Player == true first.
 *
 * Part 1:
 * This is the Player loop. PlayerState by default = 0. 
 * if (PlayerState == 0) Creature.BeginningOfTurn();
 * if (PlayerState == 1) return until Creature.Turn == false.
 * if (PlayerState == 2) Creature.EndOfTurn();
 * The BeginningOfTurn and EndOfTurn functions both run the statuses for the creature. Statuses are effects like Health += 1 etc.  
 * 
 * Part 2: 
 * Checks if Creature.Health < 1 and if so they are destroyed from the list and scene.
 * 
 * Part 3:
 * The AI loop runs. 
 * 1: Creature.Turn = true;
 * 2: Creature.BeginningOfTurn();
 * 3: Creature.AI(); The AI function is a state machine that loops until an action by the creature is done. 
 * The AI function is where pathfinding, and decision making is done. 
 * 4: Creature.EndOfTurn();
 * 
 * Part 4: 
 * PlayerStates resets to 0 as its current value would be 3 otherwise. 
 * Creature[0].Turn = true because of the sorting in Start() the player will allways be on top of the list.
 * SortLayers(); Sorts who is in front and in back when the game runs. It sorts by -> Highest Storey -> Highest Y -> Lowest X. 
 * These variables are found on the Creature.cs file, or more specifically CreatureStats.cs and the component Transform.
 */

public class Game_Manager : MonoBehaviour 
{
	public List<Creature> Creatures = new List<Creature>();
	private int PlayerState;

	void Start()
	{
		Creatures = Physics2D.CircleCastAll(transform.position,200f,Vector2.zero,Mathf.Infinity,(int)Mask.Default).Select(c => c.collider.GetComponent<Creature>())
																								  				  .OrderByDescending(c => c.Player)
																				 				 				  .ToList();		
	}

	void Update () 
	{
		 //*******************//
		//*******Part 1******//
	   //*******************//
		switch (PlayerState) 
		{
		case 0:
			Creatures[0].BeginningOfTurn();
			PlayerState++;
			break;
		case 1:
			if (Creatures[0].Turn == false)
			{
				PlayerState++;
			}
			break;
		case 2:
			Creatures[0].EndOfTurn();
			PlayerState++;
			break;
		default:
			Debug.LogError("PlayerState is > 2 or < 0 this should not happen");
			break;
		}
		if (PlayerState < 3)
		{
			return;
		}
		
		 //*******************//
		//*******Part 2******//
	   //*******************//
		Creatures.ForEach(c => Dead(c));

		 //*******************//
		//*******Part 3******//
	   //*******************//	
		for (int i = 1; i < Creatures.Count; i++)
		{
			Creatures[i].Turn = true;
			Creatures[i].BeginningOfTurn();
			Creatures[i].AI();
			Creatures[i].EndOfTurn();
		}

		 //*******************//
		//*******Part 4******//
	   //*******************//
		PlayerState = 0;
		Creatures[0].Turn = true;
		SortLayers ();
	}

	private void Dead (Creature Creature)
	{
		if (Creature.Get_Stat(Stat.Hitpoints) < 1f)
		{
			Creatures.Remove(Creature);
			Destroy (Creature.gameObject);
		}
	}
	
	private void SortLayers ()
	{
		int iLayer = 0;
		Creatures.OrderBy(s => s.Storey)
				 .ThenByDescending(p => Mathf.Floor(p.transform.position.y * 100f))
				 .ThenBy(p => Mathf.Floor(p.transform.position.x * 100f))
				 .ToList()
				 .ForEach(l => l.SpriteRenderer.sortingOrder = iLayer++);
	}
}

//Add additional AI Scripts for example adding cows. 