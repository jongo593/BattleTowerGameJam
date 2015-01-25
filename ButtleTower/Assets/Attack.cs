using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class Attack : MonoBehaviour {
	private bool playerInRange = false;
	GameObject player;
	public string oppName;
	public string attackKey;
	public int playerNum;

	private Stopwatch timer = new Stopwatch ();
	//private bool attacking = false;

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
		//UnityEngine.Debug.Log(c.GetType());
		if(c.tag.Equals(oppName) && gamestate.Instance.characters[(playerNum & 1)].isAttacking && c.GetType() == typeof(CapsuleCollider) )
		{
			// TODO change player health on hit
			//here you would proceed with the death sequence, since i dont know what it is, i made a template with a debug statement
			if(oppName.Equals("Player1"))//If Player1 Is being Attacked
			{
				gamestate.Instance.characters[0].takeDamage(gamestate.Instance.characters[1].attack);

			}
			else if(oppName.Equals("Player2"))//If Player2 Is being Attacked
			{
				gamestate.Instance.characters[1].takeDamage(gamestate.Instance.characters[0].attack);

			}
			//TODO add boss attak
			UnityEngine.Debug.Log("Player1: " + gamestate.Instance.characters[0].health + "    Player2: " + gamestate.Instance.characters[1].health);
			gamestate.Instance.characters[playerNum].isAttacking = false;
		}
	}


	void Update(){
		GameObject playerObject = GameObject.FindWithTag(oppName);
		if (Input.GetKeyDown (attackKey)) {
			if (timer.IsRunning == false) {
				timer.Start ();
				gamestate.Instance.characters[playerNum].isAttacking = true;
				//UnityEngine.Debug.Log("1");
			}
		}
		if (timer.ElapsedMilliseconds < 2000 && timer.ElapsedMilliseconds >= 1000 && timer.IsRunning) {
			gamestate.Instance.characters[playerNum].isAttacking = false;
			//UnityEngine.Debug.Log("2");
		}
		else if (timer.ElapsedMilliseconds >=2000 && timer.IsRunning) {
			timer.Reset();
			//UnityEngine.Debug.Log("3");
		}

			//TODO Run animation and play sound

	}
}
