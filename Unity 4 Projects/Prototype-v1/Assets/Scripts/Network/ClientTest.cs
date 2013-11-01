using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;

public class ClientTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TcpClient client = new TcpClient();
		
		try
		{
			Debug.Log("Connecting...");
			gameObject.GetComponent<GUIText>().text = "Connecting...";
			
			client.Connect("127.0.0.1", 37015);
			Debug.Log("Connected.");
			gameObject.GetComponent<GUIText>().text = "Connected.";
			
			String str = "Unity client here!";
			Stream stm = client.GetStream();
			
			ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Debug.Log("Transmitting...");
			gameObject.GetComponent<GUIText>().text = "Transmitting...";
			
			stm.Write(ba, 0, ba.Length);
			stm.Flush();
			Debug.Log("Transmitted.");
			gameObject.GetComponent<GUIText>().text = "Transmitted.";
			
			//byte[] bb = new byte[100];
            //int k = stm.Read(bb, 0, 100);
			
			//for (int i=0;i<k;i++)
              //  Console.Write(Convert.ToChar(bb[i]));		
			
		}
		catch
		{
			Debug.Log("Error.");
		}
		finally
		{
			client.Close();
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
