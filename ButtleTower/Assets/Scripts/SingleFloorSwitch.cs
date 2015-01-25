using UnityEngine;
using System.Collections;

public class SingleFloorSwitch : MonoBehaviour
{
	public GameObject plane;
	public GameObject gate2;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			Destroy(gate2);
		}
	}
}