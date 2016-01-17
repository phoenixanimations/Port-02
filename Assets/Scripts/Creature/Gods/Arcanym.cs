using UnityEngine;
using System.Collections;
using System_Control;
public class Arcanym : Creature
 {

	protected override void Start ()
	{
		base.Start ();
		Primary_Weapon = typeof(Nude_Hand);
		Secondary_Weapon = typeof(Vanilla_Shield_One_Handed);
		Helmet = typeof(Nude_Helmet);
		Chest = typeof(Nude_Chest);
		Legs = typeof (Nude_Legs);

		Equip(Primary_Weapon);
		Equip(Secondary_Weapon);
		Equip(Helmet);
		Equip(Chest);
		Equip(Legs);

	}

protected override void Update ()
	{
		base.Update ();
		Debug.Log("Hitpoints: " + Get_Stat(Stat.Hitpoints));
		Debug.Log("Melee Damage: " + Get_Stat(Stat.Melee_Damage));
		Debug.Log("Accuracy: " + Get_Stat(Stat.Accuracy));
		Debug.Log("Evade: "+ Get_Stat(Stat.Evade));


	}

}
