using UnityEngine;
using System.Collections;
using System_Control;

public class Spaceship : Vehicle {

	protected override void Start ()
	{
		base.Start ();
		Get_Stat(Stat.Hitpoints,2f);
	}

}
