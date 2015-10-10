using UnityEngine;
using System.Collections;

public class StatusFoundation : Movement
{
	protected Creature Cache;
	protected override void Start ()
	{
		base.Start ();
		Cache = gameObject.GetComponent<Creature>();
		Cache.AddStatus += Status;
		Cache.AddCleanUpStatus += CleanUpStatus;
	}

	protected virtual void Status ()
	{
		ModifyFront(Cache.Front);
	}

	protected virtual void CleanUpStatus (){}

	public virtual void Deactivate ()
	{
		Cache.AddStatus -= Status;
		Cache.AddCleanUpStatus -= CleanUpStatus;
		Destroy(this);
	}
}
