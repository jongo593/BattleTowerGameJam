using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Attack : MonoBehaviour {
	private bool playerInRange = false;
	GameObject player;
	public string playerName;
	public string attackKey;

	private Stopwatch timer = new Stopwatch ();
	private bool attacking = false;

	// Use this for initialization
	void Awake ()
    {
        //player = GameObject.FindGameObjectWithTag (playerName);
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider c)
	{
		//here we check for the collider involved in the collision, and check its tag  
		//if it matches enemy, proceed with the logic
		//UnityEngine.Debug.Log("thed");
		if(c.tag.Equals(playerName) && attacking)
		{
			// TODO change player health on hit
			//here you would proceed with the death sequence, since i dont know what it is, i made a template with a debug statement
			if(playerName.Equals("Player1"))//If Player1 Is being Attacked
			{
				gamestate.Instance.characters[0].takeDamage(gamestate.Instance.characters[1].attack);
			}
			else if(playerName.Equals("Player2"))//If Player2 Is being Attacked
			{
				gamestate.Instance.characters[1].takeDamage(gamestate.Instance.characters[0].attack);
			}
			//TODO add boss attak
			//UnityEngine.Debug.Log("the player has died");
			attacking = false;
		}
	}



	void Update(){
		GameObject playerObject = GameObject.FindWithTag(playerName);
		if (Input.GetKeyDown (attackKey)) {
			if (timer.IsRunning == false) {
				timer.Start ();
				attacking = true;
				//UnityEngine.Debug.Log("1");
			}
		}
		if (timer.ElapsedMilliseconds < 2000 && timer.ElapsedMilliseconds >= 1000 && timer.IsRunning) {
			attacking = false;
			//UnityEngine.Debug.Log("2");
		}
		else if (timer.ElapsedMilliseconds >=2000 && timer.IsRunning) {
			timer.Reset();
			//UnityEngine.Debug.Log("3");
		}

			//TODO Run animation and play sound

	}
}
