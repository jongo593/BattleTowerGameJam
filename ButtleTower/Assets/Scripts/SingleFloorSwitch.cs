using UnityEngine;
using System.Collections;

public class SingleFloorSwitch : MonoBehaviour
{
	public GameObject plane;
	public GameObject gate2;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player1")
		{
			Destroy(gate2);
		}
		else if (col.gameObject.tag == "Player2")
		{
			Destroy(gate2);
		}
	}
}