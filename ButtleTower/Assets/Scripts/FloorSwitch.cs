using UnityEngine;
using System.Collections;

public class FloorSwitch : MonoBehaviour
{
	public GameObject plane;
	public GameObject gate;
	private int turntSwitches = 0;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			turntSwitches++;
			Debug.Log("Number of turnt switches: " + turntSwitches);
		}
	}

	void OnTriggerExit()
	{
		turntSwitches--;
	}

	void Update()
	{
		if (turntSwitches == 2)
		{
			Destroy(gate);
		}
	}
}
