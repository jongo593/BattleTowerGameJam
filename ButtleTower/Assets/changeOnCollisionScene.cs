using UnityEngine;
using System.Collections;

public class changeOnCollisionScene : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		print ("Loaded: " + gamestate.Instance.getLevel());
	}




	void OnTriggerEnter (Collider other)
	{    
		Debug.Log ("OnTriggerEnter : other.tag = " + other.tag); // shows the tag of the trigger
		// if tag is door
		if (other.tag == "Player")
		{
			int curLevel = gamestate.Instance.getLevel();
			print ("Collision! Moving to level "+(curLevel+1).ToString());
			gamestate.Instance.setLevel(curLevel+1);
			Application.LoadLevel ("level"+(curLevel+1).ToString()); 
		}
	}
}
