using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {

	// Use this for initialization

	//public GameObject wall ;

	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Creature>().Turn)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow)) this.GetComponent<Creature>().Move("Up");
			if(Input.GetKeyDown(KeyCode.DownArrow)) this.GetComponent<Creature>().Move("Down");
			if(Input.GetKeyDown(KeyCode.LeftArrow)) this.GetComponent<Creature>().Move("Left");
			if(Input.GetKeyDown(KeyCode.RightArrow)) this.GetComponent<Creature>().Move("Right");
			if(Input.GetKeyDown (KeyCode.A)) test();
	//		if (Input.GetKeyDown(Input.inputString))
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.A))
			this.GetComponent<Creature>().Turn = false;
		}
	}
	void test () 
	{
		//Did it work?


	//	YESITLIVING gu;
	//	UseAbility(gu);
//		YESITLIVES ugh = new YESITLIVES();


		//		YESITLIVES ugh = gameObject.AddComponent<YESITLIVING>();
			this.GetComponent<Creature>().Use ();


//		ugh = gu;
//	string hi = "YESITLIVES"
	//	System.Type ugh = YESITLIVES;
		//System.Type hi = ugh.GetType();
	
	//	gameObject.AddComponent(ugh);
		//Destroy(GetComponent(myScript));
		
		//gameObject.AddComponent(ugh.GetType());
	
	//Instantiate(wall, this.transform.position + new Vector3(0,.5f,0), Quaternion.identity);

	//	Debug.Log ("this");
	}



}
