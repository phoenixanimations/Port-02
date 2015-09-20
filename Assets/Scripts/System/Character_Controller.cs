using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour
{
	void Update () 
	{
		if (this.GetComponent<Creature>().Turn)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow)) this.GetComponent<Creature>().Move("Up");
			if(Input.GetKeyDown(KeyCode.DownArrow)) this.GetComponent<Creature>().Move("Down");
			if(Input.GetKeyDown(KeyCode.LeftArrow)) this.GetComponent<Creature>().Move("Left");
			if(Input.GetKeyDown(KeyCode.RightArrow)) this.GetComponent<Creature>().Move("Right");
			if(Input.GetKeyDown (KeyCode.A)) UseWeapon();
			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.A))
			this.GetComponent<Creature>().Turn = false;
		}
	}

	void UseWeapon () 
	{
		this.GetComponent<Creature>().Use ();
	}
}
