﻿using UnityEngine;
using System.Collections;

public class Spaceship : Vehicle {

	protected override void Start ()
	{
		base.Start ();
		Hitpoints = 5;
	}

}
