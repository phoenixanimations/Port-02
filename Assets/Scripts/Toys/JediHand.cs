using UnityEngine;
public class JediHand : Item 
{
	//Example of how to use raycast! 
	protected override void Initiate ()
	{
		base.Initiate();
		Damage = 2;
		Name = "Jedi Hand";

	}

	protected override void Use ()
	{
		base.Use ();
		HitArray = Physics2D.RaycastAll(transform.position,transform.up,1.5f);
		if (HitArray.Length > 0)
		{
			for (int i = (HitArray.Length - 1); i >= 0; i--)
			{
			HitArray[i].collider.GetComponent<Creature>().Move("Up");	
			}
		}
	}
}
