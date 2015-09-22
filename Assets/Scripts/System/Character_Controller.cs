using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour
{
	void Update () 
	{
		if (this.GetComponent<Creature>().Turn)
		{
			if(Input.GetKeyDown(KeyCode.UpArrow))	{this.GetComponent<Creature>().Move("Up");   Attack (transform.up);}
			if(Input.GetKeyDown(KeyCode.DownArrow)) {this.GetComponent<Creature>().Move("Down"); Attack (-transform.up);}
			if(Input.GetKeyDown(KeyCode.LeftArrow)) {this.GetComponent<Creature>().Move("Left"); Attack (-transform.right);}
			if(Input.GetKeyDown(KeyCode.RightArrow)){this.GetComponent<Creature>().Move("Right");Attack (transform.right);}
			if(Input.GetKeyDown (KeyCode.A)) UseWeapon();

			if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.Space))
			this.GetComponent<Creature>().Turn = false;
		}
	}

	void UseWeapon () 
	{
		this.GetComponent<Creature>().Use ();
	}

	void Attack (Vector3 Direction)
	{
		gameObject.GetComponent<Creature>().Attack (Direction);
	}
}
