using UnityEngine;
using System.Collections;

public class combat : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{    
		if (other.tag == "Player")
		{
			gamestate.Instance.characters[0].takeDamage(gamestate.Instance.characters[0].health);
		}
		/*else(other.tag == "Player2")
		{
			gamestate.Instance.characters[1].takeDamage(gamestate.Instance.characters[1].health);

		}*/


	}
}
