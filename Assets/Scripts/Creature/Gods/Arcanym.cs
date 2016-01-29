using UnityEngine;
using System.Collections;
using System_Control;
public class Arcanym : Creature
 {


protected override void Start ()
	{
		base.Start ();
		
		Name = "Arcanym";
		Debug.Log(Primary_Weapon.GetComponent<Weapon_Foundation>().Status.Name);
	}

	





}
