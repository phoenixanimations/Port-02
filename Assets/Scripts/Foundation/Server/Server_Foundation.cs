using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Server_Foundation : MonoBehaviour 
{
	private int Ping = 100;

	public void Start () 
	{
//		InvokeRepeating("Upload",2f, 5f);
		InvokeRepeating("Download",2f,.5f);
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

	//Maybe switch between urls.

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

	int Different_State = 0;

	IEnumerator Get_Ping ()
	{
		string url = "";
		if (Different_State == 0)
		{
			url = "http://www.phoenixanimations.com/_server/PHP/stresstest/getstress1.php";
			Debug.Log("1\n");
		}
	
		if (Different_State == 1)
		{
			url = "http://www.phoenixanimations.com/_server/PHP/stresstest/getstress1.php";
			Debug.Log("2\n");
		}

		if (Different_State == 2)
		{
			url = "http://www.phoenixanimations.com/_server/PHP/stresstest/getstress1.php";
			Debug.Log("3\n");
		}

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

		Different_State++; 
		if (Different_State > 2)
		{
			Different_State = 0;
		}
	}
 }