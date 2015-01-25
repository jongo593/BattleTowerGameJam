using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	//for efficiency make anything that moves dynamic by giving it a rigidbody
	//this will cause gravity(in inspector)
	//a kinematic rigid body won't be affected by physics and will be considered dynamic
	public float speed;
	
	public string axisH;
	public string axisV;
	//private means it cannot be altered in the inspector
	private int count;
	
	//public GUIText countText;
	
	
	void Start()
	{
		count = 0;
		//countText.text = "Count: " + count.ToString ();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis (axisH);
		float moveVertical = Input.GetAxis (axisV);
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		//rigidbody.AddForce(movement * speed * Time.deltaTime);
		rigidbody.transform.position += (movement * speed);
		
	}//ends FixedUpdate()



	//Use this to test collision with other objects
	//This .cs needs to be attached to a player character
	void OnTriggerEnter(Collider other)
	{
		//Destroy (other.gameObject);
		//"PickUp" is Tag for the prefab square
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			
		}//ends if()
	}//end OnTrigger()
}//ends class