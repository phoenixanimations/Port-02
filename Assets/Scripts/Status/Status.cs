using UnityEngine;
using System.Collections;

public class Status : Movement 
{
	protected override void Start () 
	{
		base.Start();
		this.gameObject.GetComponent<Creature>().AddStatus += Activate;
	}

	protected virtual void Activate () {}

	public virtual void Deactivate ()
	{
		this.gameObject.GetComponent<Creature>().AddStatus -= Activate;
		Destroy(this);
	}
}
