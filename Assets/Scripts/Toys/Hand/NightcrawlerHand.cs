using UnityEngine;
using System.Collections;

public class NightcrawlerHand : ItemFoundation 
{
	public float Push = 2f; //Fix teleport in object glitch. Update Jumper too. 
	protected override void Initiate ()
	{
		base.Initiate ();
		Damage = 2;
		Name = "Zed's Hand";
		
	} 

	protected override void Use ()
	{
		base.Use ();
		Hit = Physics2D.Raycast(transform.position,Front,x);
		if (Hit.collider != null) 
		{
			HitArray = Physics2D.RaycastAll(transform.position,Front,Push);
			Hit = Physics2D.Raycast(HitArray[HitArray.Length - 1].collider.transform.position,Front,x);
			if (HitArray.Length >= 0 && Hit.collider == null)
			{
				transform.position = (HitArray[HitArray.Length - 1].collider.transform.position + (Vector3.Scale(new Vector3 (x,y,0),Front)));
			}
		}
	}


}
