using UnityEngine;
using System.Collections;

public class endgame : MonoBehaviour {

	void OnGUI () 
	{
		GUI.TextArea (new Rect (100, 100, 150, 30), "Game Over");

		if(GUI.Button(new Rect (30, 30, 150, 30), "Start Game"))
		{
			startGame();
		}	
	}

	private void startGame()
	{
		print("Starting game");
		
		DontDestroyOnLoad(gamestate.Instance);
		gamestate.Instance.startState();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
