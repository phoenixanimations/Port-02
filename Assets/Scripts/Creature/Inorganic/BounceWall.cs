using UnityEngine;
using System.Collections;

public class BounceWall : Wall 
{
	protected override void Start ()
	{
		base.Start ();
		gameObject.AddComponent<BounceWhenHit>();
	}


}
