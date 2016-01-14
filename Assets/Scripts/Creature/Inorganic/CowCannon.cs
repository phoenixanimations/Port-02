using UnityEngine;
using System.Collections;

public class CowCannon : Creature
{
	public GameObject Cow;

	private bool LightSwitch;

	protected override void Start ()
	{
		base.Start ();
		CreatureType = "Vehicle";
		ModifyLevel(HitpointsLevelAmount:5);
	}

	public void VehicleMessage (GameObject creature)
	{
	
		if (creature.GetComponent<Creature>().Front == -Front)
		{
			LightSwitch = !LightSwitch;
				if (LightSwitch)
				{
					gameObject.AddComponent<Follow>();
					gameObject.GetComponent<Follow>().Name = creature.name;
				}
				if (!LightSwitch)
				{
					gameObject.GetComponent<Follow>().Deactivate();
				}
		}

		Hit = Physics2D.Raycast(transform.position,-Front,x);
		if (Hit.collider == null)
		{
			if (creature.GetComponent<Creature>().Front == RightFront (Front) || creature.GetComponent<Creature>().Front == RightFront (-Front))
			{

				Instantiate(Cow,transform.position + (Vector3.Scale(new Vector3(x,y,0),-Front)),transform.rotation);
			}
		}

	}

	private Vector3 RightFront (Vector3 Direction)
	{
		Vector3 RightDirection;
		RightDirection.x = Direction.y;
		RightDirection.y = Direction.x;
		RightDirection.z = Direction.z;
		return RightDirection;
	}

	public override void AI ()
	{
		base.AI ();
	}
}
