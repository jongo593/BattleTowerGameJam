using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class BossAI : MonoBehaviour {
	
	public Transform target; //the enemy's target
	public int moveSpeed = 3; //move speed
	public int rotationSpeed = 3; //speed of turning

	private Stopwatch timer = new Stopwatch ();

	private bool isAttacking = false;
	private string targetTag = "Player1";

	private Transform myTransform; //current transform data of this enemy
	private bool player1Trigger = false;
	private bool player2Trigger = false;
	public int bossDamage = 50;

	public string changeTarget () {

		string player = "Player" + Random.Range (1, 3);
		UnityEngine.Debug.Log (player);
		return player;

	}

	public void Awake() { 
		myTransform = transform; //cache transform data for easy access/preformance }
	}
	public void Start() {
		target = GameObject.FindWithTag(changeTarget()).transform; //target the player
	}
	public void Update () { //rotate to look at the player

		if (isAttacking) {
				
			if (!timer.IsRunning) {
				timer.Start ();
				//gamestate.Instance.characters[playerNum].isAttacking = true;
				//UnityEngine.Debug.Log ("1");
			}
			else if (timer.ElapsedMilliseconds < 3000 && timer.ElapsedMilliseconds >= 1000 && timer.IsRunning) {

				//ATTACKING
				//gamestate.Instance.characters [playerNum].isAttacking = false;
				//UnityEngine.Debug.Log ("2");
			}
			else if (timer.ElapsedMilliseconds >= 3000 && timer.IsRunning) {
				timer.Reset ();
				if(player1Trigger)
				{
					player1Trigger = false;
					gamestate.Instance.characters[0].takeDamage(bossDamage);
				}
				if(player2Trigger)
				{
					player2Trigger = false;
					gamestate.Instance.characters[1].takeDamage(bossDamage);
				}
				UnityEngine.Debug.Log("Player1: " + gamestate.Instance.characters[0].health + "    Player2: " + gamestate.Instance.characters[1].health);
				//UnityEngine.Debug.Log ("3");
				isAttacking = false;
				target = GameObject.FindWithTag(changeTarget()).transform; //target the player
				
			}

		}

		else {

			var newRotation = Quaternion.LookRotation (-(myTransform.position - target.position));
			newRotation.x = 0.0f;
			newRotation.z = 0.0f;
			//Vector3 rotation = new Vector3 (target.position.x - myTransform.position.x, myTransform.position.y, myTransform.position.z);
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, newRotation, rotationSpeed * Time.deltaTime);
			//move towards the player
			Vector3 move = myTransform.forward;
			move.y = 0.0f;
			myTransform.position += move * moveSpeed * Time.deltaTime;

		}
}

	public void OnTriggerEnter (Collider c) 
	{
		if (c.GetType() == typeof(SphereCollider) && c.tag.Equals("Player1")) {
			//Cleave
			//Debug.Log ("Cleave");

			isAttacking = true;
			player1Trigger = true;
			//timer.Start();
		}
		if (c.GetType() == typeof(SphereCollider) && c.tag.Equals("Player2")) {
			//Cleave
			//Debug.Log ("Cleave");
			isAttacking = true;
			player2Trigger = true;
			//timer.Start();
		}

	}
	public void OnTriggerExit (Collider other) 
	{
		if (other.GetType() == typeof(CapsuleCollider) && other.tag.Equals("Player1")) {
			//Cleave
			//Debug.Log ("Cleave");
			player1Trigger = false;
			//timer.Start();
		}
		if (other.GetType() == typeof(CapsuleCollider) && other.tag.Equals("Player2")) {
			//Cleave
			//Debug.Log ("Cleave");
			player2Trigger = false;
			//timer.Start();
		}
		
	}

}


