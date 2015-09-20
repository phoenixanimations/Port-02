using UnityEngine;
using System.Collections;

public class GameManager_Test
{
	//public static int Test;
	//static void hmm (){Debug.Log ("hi");}
}






//using UnityEngine;
//using System.Collections;
//
//
//public enum GameState { NullState, Intro, MainMenu, Game } //equip, move,item, attack, endturn
//public delegate void OnStateChangeHandler();
//
//public class GameManager {
//		
//		private static GameManager _instance = null;	
//		public event OnStateChangeHandler OnStateChange;
//		public GameState gameState { get; private set; }
//		
//		protected GameManager() {}
//		
//		// Singleton pattern implementation
//		public static GameManager Instance { 
//			get {
//				if (_instance == null) {
//					_instance = new GameManager(); 
//				}  
//				return _instance;
//			} 
//		}
//		
//		public void SetGameState(GameState gameState) {
//			this.gameState = gameState;
//			if(OnStateChange!=null) {
//				OnStateChange();
//			}
//		}
//	}
//
