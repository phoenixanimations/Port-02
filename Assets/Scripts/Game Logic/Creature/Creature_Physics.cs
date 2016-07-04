using UnityEngine;
using System.Collections;
using System.Linq;
using System_Control;

public class Creature_Physics : Creature_States 
{
	private float FallDistance;
	public override void Beginning_Of_Turn ()
	{
		base.Beginning_Of_Turn ();
		RecordHeight(this,Raycast);
	}	

	public override void Jumping ()
	{
		base.Jumping ();
		if (Raycast.SearchForCreature(Front,Storey)  
		    && Raycast.SearchForHeight(Front,true)
			&& Get_Stat(Stat.Jump) >= Raycast.TargetMultipleCreature.Count)
			{
				float x = Raycast.TargetCreature.transform.position.x;
				float y = Raycast.TargetCreature.transform.position.y;
				float AddHeight = Raycast.TargetMultipleCreature.Select(h => h.Height).Sum();
				Vector2 JumpLocation = new Vector2(x, y + AddHeight);			
				
				transform.position = JumpLocation;
				Storey = Raycast.TargetMultipleCreature.OrderByDescending(s => s.Storey).ToList()[0].Storey + 1;
			}
	}

	public override void End_Of_Turn ()
	{
		base.End_Of_Turn ();
		RecordHeight(this,Raycast);
		Fall(this, Raycast);
	}


	private void RecordHeight (Creature_States Creature, Raycast Raycast)
	{
		if (Raycast.SearchForCreature(Vector2.down,Creature.Storey -1))
			FallDistance = Raycast.TargetCreature.Height;
	}
		
	private void Fall (Creature_States Creature, Raycast Raycast)
	{
		if (Raycast.SearchForCreature(Vector2.down,Creature.Storey -1) == false && 
			Creature.Storey > 1)	
		{
			float x = Creature.transform.position.x;
			float y = Creature.transform.position.y;
			Vector2 FallLocation = new Vector2 (x, y - FallDistance);
			
			transform.position = FallLocation;	
			Creature.Storey--;
		}
	}
}

//In the last version, you should be able to drop storeys and just have GlobalHeight and CreatureHeight.
//Do this by stacking height, and then raycasting and grabbing the last height.
//Jump will then be 1.98 if you wanted to jump one storey.

//Your fall Distance should be fixed. And it should always be one storey. 
//The game should check when your falling if you can fall 1 storey, and if you can't then fall x amount. If GlobalHeight -= FallDistance is < 0 GlobalHeight = 0. 
//Your jump should be half a storey.

//Shooting/Attacking should be inbetween storeys. Or you can label them as storeys and the game converts it. Like 1 storey = between x && x + 1.98f.

//Finally change code design to follow camal case?