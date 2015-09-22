using UnityEngine;
using System.Collections;

public class Alien : Creature
{

	protected override void Start ()
	{
		base.Start();
		Health = 2;
//		Weapon = typeof(JediHand);
//		Equip(Weapon);
		Weapon = typeof(Raygun);
		Equip(Weapon);
//		Weapon = typeof(Grapple);
//		Weapon = typeof(Tractor);
//		Helmet = typeof(ForcePush);
		Equip(Weapon);
//		Equip(Helmet);
	}

}
