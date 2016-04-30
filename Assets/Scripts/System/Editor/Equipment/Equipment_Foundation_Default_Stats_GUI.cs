using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System_Control;

public class Equipment_Foundation_Default_Stats_GUI : Editor 
{
	protected void Default_Stats (ref Equipment_Foundation Weapon_Editor)
	{
		if (GUILayout.Button("Default Stats",GUILayout.Height(14f),GUILayout.Width(80f)))
		{
			switch (Weapon_Editor.Class) 
			{
			case Assign_Class.Melee:
				if (Weapon_Editor.Subclass == Assign_Subclass.Sword)
				{
					if (Weapon_Editor.Two_Handed == false)
					{
						Set_Default_Stats(ref Weapon_Editor,0f,1f,1f,1f,0,0,0,1f,1.5f,0f,0f,1f,.5f,0,0,0,0,0,0,15f);
					}
					else 
					{
						Set_Default_Stats(ref Weapon_Editor,0f,1f,1f,1f,0,0,0,1f,4.5f,0f,0f,2f,0f,0,0,0,0,0,0,30f);
					}
				}
				
				if (Weapon_Editor.Subclass == Assign_Subclass.Spear)
				{
					Weapon_Editor.Two_Handed = true;
					Set_Default_Stats(ref Weapon_Editor,0f,1f,1f,2f,0,0,0,1f,4.5f,0f,0f,2f,0f,0,0,0,0,0,0,30f);
				}
				break;
			case Assign_Class.Magic:
				if (Weapon_Editor.Subclass == Assign_Subclass.Wand)
				{
					Weapon_Editor.Two_Handed = false;
					Set_Default_Stats(ref Weapon_Editor,0f,1f,1f,5f,0,0,0,1f,0f,1f,0f,1f,.5f,20,40,5,5,5,0,20);					
				}
				if (Weapon_Editor.Subclass == Assign_Subclass.Staff)
				{
					Weapon_Editor.Two_Handed = true;
					Set_Default_Stats(ref Weapon_Editor,0f,1f,1f,5f,0,0,0,1f,0f,3f,0f,2f,0f,60,80,10,10,10,0,30);
				}
				if (Weapon_Editor.Subclass == Assign_Subclass.Spellbook)
				{
					Weapon_Editor.Class = Assign_Class.Shield;
					Set_Default_Stats(ref Weapon_Editor,0f,0f,0f,0f,0,0,0,1f,0f,.2f,0f,.2f,1f,20,20,7.5f,7.5f,7.5f,0);
				}
				break;
			case Assign_Class.Archery:
				if (Weapon_Editor.Subclass == Assign_Subclass.Bow)
				{
					Weapon_Editor.Two_Handed = true;
					Set_Default_Stats(ref Weapon_Editor,0f,3f,4f,7f,0,0,0,1f,0f,0f,3f,3f,0f,0,0,0,0,0,0,10);
				}
				if (Weapon_Editor.Subclass == Assign_Subclass.Crossbow)
				{
					Weapon_Editor.Two_Handed = false;
					Set_Default_Stats(ref Weapon_Editor,0f,3f,3f,5f,0,0,0,1f,0f,0f,1f,1.5f,.5f,0,0,0,0,0,0,5);
				}
				break;
			case Assign_Class.Shield:
				if (Weapon_Editor.Class == Assign_Class.Shield && Weapon_Editor.Subclass == Assign_Subclass.None)
				{
					Set_Default_Stats(ref Weapon_Editor,0f,0f,0f,0f,0,0,0,1f,0f,0f,0f,0f,1.5f,0,0,12.5f,12.5f,12.5f,.5f);
				}
				if (Weapon_Editor.Subclass == Assign_Subclass.Spellbook)
				{
					Weapon_Editor.Class = Assign_Class.Shield;
					Set_Default_Stats(ref Weapon_Editor,0f,0f,0f,0f,0,0,0,1f,0f,.2f,0f,.2f,1f,20,20,7.5f,7.5f,7.5f);
				}
				break;
			case Assign_Class.Armor:
				Weapon_Editor.Subclass = Assign_Subclass.None;
				Set_Default_Stats(ref Weapon_Editor,0f,0f,0f,0f,0,0,0,1f,0f,0f,0f,0f,0f,0,0,25f,25f,25f,1f);
				break;
			case Assign_Class.Ammo:
				Set_Default_Stats(ref Weapon_Editor,0f,0f,0f,0f,0,0,0,1f,0f,0f,0f,0f,0f,0,0,0f,0f,0f,0f);
				break;
			default:
				EditorGUILayout.HelpBox("This Class isn't supported",MessageType.Error);
				break;
			}
		}
	}

	private void Set_Default_Stats (ref Equipment_Foundation Weapon_Editor, float Area_Of_Effect, float Number_Of_Attacks,
		float Minimum_Distance, float Maximum_Distance, float Movement, float Jump, float Knockback, float Level, float Melee_Multiplier,
		float Magic_Multiplier, float Archery_Multiplier, float Accuracy, float Evade, float Critical_Damage, float Critical_Chance, float Melee_Resistance,
		float Magic_Resistance, float Archery_Resistance,float Hitpoints_Multiplier = 0f, float Energy = 0f, Defect Defect = Defect.None)
	{
		Weapon_Editor.Get_Stat(Stat.Area_Of_Effect,Area_Of_Effect,true);
		Weapon_Editor.Get_Stat(Stat.Number_Of_Attacks,Number_Of_Attacks,true);
		Weapon_Editor.Get_Stat(Stat.Minimum_Distance,Minimum_Distance,true);
		Weapon_Editor.Get_Stat(Stat.Maximum_Distance,Maximum_Distance,true);
		Weapon_Editor.Get_Stat(Stat.Movement,Movement,true);
		Weapon_Editor.Get_Stat(Stat.Jump,Jump,true,true);
		Weapon_Editor.Get_Stat(Stat.Knockback,Knockback,true);
		Weapon_Editor.Level = Level;
		Weapon_Editor.Stat_Multiplier[(int)Stat.Melee_Damage] = Melee_Multiplier;
		Weapon_Editor.Stat_Multiplier[(int)Stat.Magic_Damage] = Magic_Multiplier;
		Weapon_Editor.Stat_Multiplier[(int)Stat.Archery_Damage] = Archery_Multiplier;
		Weapon_Editor.Stat_Multiplier[(int)Stat.Accuracy] = Accuracy;
		Weapon_Editor.Stat_Multiplier[(int)Stat.Evade] = Evade;
		Weapon_Editor.Get_Stat(Stat.Critical_Damage,Critical_Damage,true,true);
		Weapon_Editor.Get_Stat(Stat.Critical_Chance,Critical_Chance,true,true);
		Weapon_Editor.Get_Stat(Stat.Melee_Resistance,Melee_Resistance,true,true);
		Weapon_Editor.Get_Stat(Stat.Magic_Resistance,Magic_Resistance,true,true);
		Weapon_Editor.Get_Stat(Stat.Archery_Resistance,Archery_Resistance,true,true);
		Weapon_Editor.Get_Stat(Stat.Energy,Energy,true,true);
		Weapon_Editor.Stat_Multiplier[(int)Stat.Hitpoints] = Hitpoints_Multiplier;
		Weapon_Editor.Defect = Defect;
		Weapon_Editor.Passives.Clear();
	}
}
