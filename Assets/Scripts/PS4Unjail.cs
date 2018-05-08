using System;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class PS4Unjail : MonoBehaviour
{
	private string infoText;
	private int infoCount = 0;

	[DllImport("libPS4Unjail")]
	private static extern int FreeUnjail();

	[DllImport("libPS4Unjail")]
	private static extern int GetPid();

	[DllImport("libPS4Unjail")]
	private static extern int GetUid();


	void OnGUI()
	{
		GUI.TextArea(new Rect(0,0,Screen.width-1,Screen.height-64), infoText);
		GUI.TextArea(new Rect(0,Screen.height-32,Screen.width,31), infoCount.ToString());
	}

	void Update()
	{
		infoCount ++;
	}

	void Start()
	{
		System.Console.WriteLine("SimpleNativePlugin start called" );

		infoText += "BEFORE UNJAIL\n\n";
		infoText += "Current PID ( Process ID ): " + GetPid();
		infoText += "\nCurrent UID ( Ownser User ID ) : " + GetUid();
		infoText += "\nApplying UNJAIL";
		FreeUnjail();
		infoText += "\nAfter Unjail";
		infoText += "Current PID ( Process ID ): " + GetPid();
		infoText += "\nCurrent UID ( Ownser User ID ) : " + GetUid();

	}
}