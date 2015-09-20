using UnityEngine;
using System.Collections;

public class Alien : Creature {

	protected override void Start ()
	{
		base.Start();
//		Health = 2;
//		Damage = 5;
		Weapon = typeof(JediHand);
		Equip(Weapon);
		//gameObject.AddComponent<ForcePush>();

	}


	protected override void Update ()
	{	
		base.Update ();
	}
}
