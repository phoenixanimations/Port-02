using UnityEngine;
using System.Collections;
using System;
using System_Control;

public class Attack : Raycast
{
	public Equipment_Foundation Primary;
	public Equipment_Foundation Secondary;
	public Equipment_Foundation Helmet;
	public Equipment_Foundation Chest;
	public Equipment_Foundation Legs;
	private Creature Cache_Creature;

	string Class;
	float Class_Level = 0f;
	float Accuracy = 0f;
	float Resistance = 0f;
	float Critical = 0f;
	float Damage = 0f;
	float How_Many_Times = 0f;
	float One_More_Time = 0f;

	private bool Dual_Wield_Equipped ()
	{
		if (Secondary.Subclass == Assign_Subclass.One_Handed) return true;
		return false;
	}
	
	protected override void Start ()
	{
		base.Start ();
		Cache_Creature = gameObject.GetComponent<Creature>();
		Primary = Cache_Creature.Primary_Weapon;
		Secondary = Cache_Creature.Secondary_Weapon;
		Helmet = Cache_Creature.Helmet;
		Chest = Cache_Creature.Chest;
		Legs = Cache_Creature.Legs;
	}
	
	private void Passives (Equipment_Foundation Primary_Or_Secondary, Creature Adversary, Phase Attack_Phase)
	{
		Primary_Or_Secondary.Attack_Status(Attack_Phase);
		Helmet.Attack_Status(Attack_Phase);
		Chest.Attack_Status(Attack_Phase);
		Legs.Attack_Status(Attack_Phase);
		Adversary.Counter_Attack(Attack_Phase);
	}

	public void Hit_Me_Baby (Equipment_Foundation Primary_Or_Secondary) //Assign Weapon; Look into prefabs. 
	{


		
		Hit = Physics2D.Raycast(transform.position, Cache_Creature.Front, Cache_Creature.x * Cache_Creature.Get_Stat(Stat.Distance));
		if (Hit.collider != null)
		{

		Creature Adversary;
		Adversary = Hit.collider.GetComponent<Creature>();
		Class_Level = Cache_Creature.Get_Stat(Primary_Or_Secondary.Class.ToString() + "_Level");
		Class = Primary_Or_Secondary.Class.ToString();

			while (One_More_Time < How_Many_Times)
			{
				Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Begin);
				How_Many_Times = Primary_Or_Secondary.Get_Stat(Stat.Number_Of_Attacks);

  //**************************************//
 //*********Calculate: Accuracy**********//
//**************************************//
				Accuracy += (	50f 
				 				
								* 

								((Tier.Formula(Class_Level) 		+ Primary_Or_Secondary.Get_Stat(Stat.Accuracy) + 
								 Helmet.Get_Stat(Stat.Accuracy) + Chest.Get_Stat(Stat.Accuracy) + Legs.Get_Stat(Stat.Accuracy))
								/ 
								((Tier.Formula(Adversary.Get_Stat(Primary_Or_Secondary.Class + "_Level")) + 
								  Adversary.Primary_Weapon.Get_Stat(Stat.Evade) + Adversary.Secondary_Weapon.Get_Stat(Stat.Evade) + 
								  Adversary.Helmet.Get_Stat(Stat.Accuracy) 	    + Adversary.Chest.Get_Stat(Stat.Accuracy)  		  + Adversary.Legs.Get_Stat(Stat.Accuracy))))
							);
	
  //**************************************//
 //******Calculate: Base Damage**********//
//**************************************//

				
				if (Dual_Wield_Equipped ())
				{
					Damage += (Tier.Formula(Cache_Creature.Get_Stat(Class + "_Level")) * 0.5f) +
							   Primary_Or_Secondary.Get_Stat(Class + "_Damage") + 
							  ((Helmet.Get_Stat(Class + "_Damage") + Chest.Get_Stat(Class + "_Damage") + Legs.Get_Stat(Class + "_Damage")) * 0.5f );
				}
				if (!Dual_Wield_Equipped ()) 
				{
					Damage += (Tier.Formula(Cache_Creature.Get_Stat(Class + "_Level"))) +
							   Primary_Or_Secondary.Get_Stat(Class + "_Damage") + 
							  ((Helmet.Get_Stat(Class + "_Damage") + Chest.Get_Stat(Class + "_Damage") + Legs.Get_Stat(Class + "_Damage")));
				}
	
  //**************************************//
 //*****Calculate: Critical Damage*******//
//**************************************//

				Critical += (
								Damage 
								* 
								(Cache_Creature.Get_Stat(Stat.Critical_Damage) / 100)
							);

  //**************************************//
 //*****Calculate: Resistance Damage*****//
//**************************************//
	
				Resistance += (
								Damage
								*
								(Cache_Creature.Get_Stat(Class + "_Resistance") / 100)
							  );

  //**************************************//
 //*****Calculate: Total Damage**********//
//**************************************//
	
				Damage += -Resistance + Critical;

  //**************************************//
 //**************Dice Roll***************//
//**************************************//	
	
				if (Accuracy >= UnityEngine.Random.Range(0f,100f))
				{	
					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Hit);				
					Adversary.Get_Stat(Stat.Hitpoints,-Damage);	
					if (Primary_Or_Secondary.Class == Assign_Class.Melee) Cache_Creature.Get_Stat(Stat.Energy,15f);
					if (Primary_Or_Secondary.Class == Assign_Class.Magic) Cache_Creature.Get_Stat(Stat.Energy,25f);
					if (Primary_Or_Secondary.Class == Assign_Class.Archery) Cache_Creature.Get_Stat(Stat.Energy,5f);
				}
				else
				{
					Passives (Primary_Or_Secondary, Adversary, Phase.Attack_Miss);				
				}
				One_More_Time++;
				Passives (Primary_Or_Secondary, Adversary, Phase.Attack_End);
			}
		}
		
	}
}