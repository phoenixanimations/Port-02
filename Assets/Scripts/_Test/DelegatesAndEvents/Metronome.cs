using UnityEngine;
using System.Collections;

public class Metronome : object {

	public event TickHandler Tick;
	public delegate void TickHandler(Metronome m);

	public void Starting() 
		{
			if (Tick != null)
			{
			Tick(this);
			}
		}

}
