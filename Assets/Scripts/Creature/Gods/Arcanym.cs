using UnityEngine;
using System.Collections;

public class Arcanym : Creature {

	protected override void Start ()
	{
		base.Start ();
		ModifyLevel(1f,1f,1f,1f);
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

}
