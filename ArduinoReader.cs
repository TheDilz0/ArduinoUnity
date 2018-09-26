using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.IO;
//
using UnityEngine.UI;

public class ArduinoReader : MonoBehaviour
{
	SerialPort sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);

	public int nbVars;

	public Canvas c;
	public Text[] t;
	int n = 0;

	void Start()
	{
		sp.Open();
		sp.ReadTimeout = 1;
		t = c.GetComponentsInChildren<Text>();
	}

	private void Update()
	{
		if (sp.IsOpen)
		{

			try
			{
				int nb = sp.ReadByte() * 4;
				t[n].text = nb.ToString();

				if (n+1 >= nbVars)
				{
					n = 0;
				}
				else
				{
					n += 1;
					//print("reset");
				}

				sp.BaseStream.Flush();
				
			}
			catch (System.Exception)
			{
				//throw;
			}
		}
	}
}

/*
 
	using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.IO;
//
using UnityEngine.UI;

public class ArduinoReader : MonoBehaviour
{
	SerialPort sp = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
	public float[] Sensors;

	//vars
	public string value;
	public string[] ArdVar;
	public int p;

	//
	public Canvas c;
	public Text[] t;
	//

	void Start()
	{
		sp.Open();
		sp.ReadTimeout = 10;
		t = c.GetComponentsInChildren<Text>();
	}

	private void Update()
	{
		if (sp.IsOpen)
		{

			try
			{
				value = sp.ReadLine();

				ArdVar = value.Split('/');

				foreach(string i in ArdVar)
				{
					string[] result = i.Split(':');
					Sensors[int.Parse(result[0])] = float.Parse(result[1]);
				}
				
				foreach (float f in Sensors)
				{
					p = System.Array.IndexOf(Sensors, f);
					//
					t[p].text = f.ToString();
				}
				
				sp.BaseStream.Flush();
				
			}
			catch (System.Exception)
			{
				//throw;
			}
		}
	}
}

  */
