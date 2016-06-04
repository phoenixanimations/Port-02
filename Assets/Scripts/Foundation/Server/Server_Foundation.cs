using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Server_Foundation : MonoBehaviour 
{
	private int Ping = 100;

	public void Start () 
	{
		InvokeRepeating("Upload",2f,1f);
//		InvokeRepeating("Download",2f,.25f);
	}
	
	void Upload ()
	{
		Ping++;
		StartCoroutine(Upload_Ping());
	}
	
	void Download ()
	{
		StartCoroutine(Get_Ping());
	}


	IEnumerator Upload_Ping ()
	{
		string Ping_URL = "http://www.phoenixanimations.com/_server/PHP/stresstest/updatestress.php";
		WWWForm Ping_Form = new WWWForm();	
		Ping_Form.AddField("ping", Ping);
		
		WWW Upload = new WWW(Ping_URL, Ping_Form);

		yield return Upload;

		if(!string.IsNullOrEmpty(Upload.error)) 
		{
			Debug.Log( "Upload_Ping Error: " + Upload.error);
		} 
		else 
		{
			Debug.Log("Success");
		}
	}

	IEnumerator Get_Ping ()
	{
	    string url = "http://www.phoenixanimations.com/_server/PHP/stresstest/getstress.php";
	    WWW www = new WWW(url);
	    yield return www;
		
		if (www.error == null)
        {
        	Debug.Log("Done: " + www.text);
        } 
		else 
		{
            Debug.Log("Get_Ping Error: "+ www.error);
        } 
	}
 }