using UnityEngine;
using System.Collections;

public class Listener : object {

	public void Subscribe(Metronome m)
	{
		m.Tick += new Metronome.TickHandler(HeardIt);
	
	
	}

	private void HeardIt(Metronome m)
	{
		Debug.Log ("Message Recieved");
	}

}