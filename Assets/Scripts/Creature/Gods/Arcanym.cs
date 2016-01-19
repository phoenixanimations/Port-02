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
		Equip(Primary_Weapon,Assign_Hand.Primary);
		Equip(Secondary_Weapon,Assign_Hand.Secondary);
		Equip(Helmet);
		Equip(Chest);
		Equip(Legs);
		
	}




}
