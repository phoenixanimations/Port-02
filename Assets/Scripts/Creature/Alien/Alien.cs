using UnityEngine;
using System.Collections;

public class Alien : Creature
{
	protected override void Start ()
	{
		base.Start();
		ModifyLevel(HitpointsLevelAmount:2);
		//Hitpoints = 2;
//		Weapon = typeof(Duplicator);
//		Weapon = typeof(FireInTheDisco);
//		Weapon = typeof(Grapple);
//		Weapon = typeof(JediHand);
//		Weapon = typeof(JediPull);
//		Weapon = typeof(NightcrawlerHand);
//		Weapon = typeof(Raygun);
//		Weapon = typeof(StickOfGum);
//		Weapon = typeof(Tractor);
//		Weapon = typeof(TunnelGun);

//		Helmet = typeof(ForcePush);
//		Chest = typeof(TunnelPortal);
//		Chest = typeof(AddDamage);
//		Chest = typeof(BounceWhenHit);
//		Chest = typeof(IdleAddDamage);
//		Legs = typeof(IdleAddDamage);
//		Legs = typeof(WalkHeal);
//		Legs = typeof(WalkAddDamage);

//		Equip(Weapon);
//		Equip(Helmet);
//		Equip(Chest);
//		Equip(Legs);
	}
}
