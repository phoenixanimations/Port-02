using UnityEngine;
using System.Collections;

public class Turns:MonoBehaviour
{
	void Start () 
	{}

	void Update () 
	{
		//Debug.Log (GameManager.Test);
	}
}












//using UnityEngine;
//using System.Collections;
//
//public class Turns : MonoBehaviour {
//	
//	GameManager GM;
//
//	public Creature test;
//
//	void Awake ()
//	{
//
//
//		
//		GM = GameManager.Instance;
//		GM.OnStateChange += HandleOnStateChange;
////		GM.OnStateChange += test.Test;
//
////		Debug.Log("Current game state when Awakes: " + GM.gameState);
//		
//		GM.SetGameState(GameState.Intro);
//
//	}
//
//
//	void Update () 
//	{
//
//
//
//
//	}
//
//
//	
//	public void HandleOnStateChange ()
//	{
//		//Debug.Log("Handling state change to: " + GM.gameState);
//	}
//
//
//}








/*
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//
//public class Turns : MonoBehaviour {
//
//	public List<Creature> Actors;
////	private Creature Status;
////	private Creature Function; 
//
//
//	// Use this for initialization
//	void Start () {
//	
//	}
//
//	int iCount;
//	// Update is called once per frame
//
//	private void updateCount (bool Turn) 
//	{
//		if (!Turn)
//		{
//		iCount++;
//		if (iCount >= Actors.Count) iCount = 0;
//		}
//	}
//
//	void Update () 
//	{
//		Actors[iCount].AI();
//		updateCount(Actors[iCount].Turn);
//		Actors[iCount].Turn = true;
//
////		Actors[iCount].AI();
//		
//		//		Debug.Log (iCount);
////		if (Actors[iCount].Player && Actors[iCount].Turn){
////			Actors[iCount].GetComponent<Character_Controller>().enabled = true;
//////			Character_Controller player;
//////			player = Actors[iCount].GetComponent<Character_Controller>();
//////			player.enabled = !player.enabled;
////			return;
////		}
////		if (Actors[iCount].Player && !Actors[iCount].Turn){
////		Actors[iCount].GetComponent<Character_Controller>().enabled = false;
////		}
////
////		if (Actors[iCount].Turn && !Actors[iCount].Player){
////			Actors[iCount].AI();
////			return;
////		}
////
////
////
////
////		if (iCount < Actors.Length -1)
////		{
////		//Debug.Log (Actors[iCount]);
////		Actors[iCount].Turn = true;
//////		Actors[iCount].Passive();
////		
////		
////		}
////		else{ iCount = 0;}
////		iCount++;
////
//
//		Debug.Log (Actors[iCount]);
////		Debug.Log(iCount);
//
//	}
//
//
//}
*/