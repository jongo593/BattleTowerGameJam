using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class gamestate : MonoBehaviour {

	// Declare properties
	private static gamestate instance;
	private int activeLevel;			// Active level
	private int stageNumber;
					// Characters Experience Points
	public Character[] characters;
	public List<string> puzzleStages;
	public List<string> BossStages;
	// ---------------------------------------------------------------------------------------------------
	// gamestate()
	// --------------------------------------------------------------------------------------------------- 
	// Creates an instance of gamestate as a gameobject if an instance does not exist
	// ---------------------------------------------------------------------------------------------------
	public static gamestate Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameObject("gamestate").AddComponent<gamestate>();
			}
			
			return instance;
		}
	}	
	
	// Sets the instance to null when the application quits
	public void OnApplicationQuit()
	{
		instance = null;
	}
	// ---------------------------------------------------------------------------------------------------
	
	
	// ---------------------------------------------------------------------------------------------------
	// startState()
	// --------------------------------------------------------------------------------------------------- 
	// Creates a new game state
	// ---------------------------------------------------------------------------------------------------
	public void startState()
	{
		print ("Creating a new game state");
		// Set default properties:
		activeLevel = 1;
		name = "My Character";

		//Create Players
		InitialChracters ();

		//Initialize Scenes
		stageNumber = 1;
		puzzleStages = new List<string> () {"level1"};
		BossStages = new List<string> () {"level2"};

		// Load level 1
		//TODO change to initial scene
		Application.LoadLevel("level1");
	}

	public bool gameover(){
		foreach (Character player in characters) {
			if(player != null && !player.isDead){
				return false;
			}
			return true;
		}
		return true;
	}

	public void Update(){
		if (gameover ()) {
			Application.LoadLevel("endgame");
			return;
		}
		return;
	}

	// ---------------------------------------------------------------------------------------------------
	// getLevel()
	// --------------------------------------------------------------------------------------------------- 
	// Returns the currently active level
	// ---------------------------------------------------------------------------------------------------
	public int getLevel()
	{
		return activeLevel;
	}
	
	
	// ---------------------------------------------------------------------------------------------------
	// setLevel()
	// --------------------------------------------------------------------------------------------------- 
	// Sets the currently active level to a new value
	// ---------------------------------------------------------------------------------------------------
	public void setLevel(int newLevel)
	{
		// Set activeLevel to newLevel
		activeLevel = newLevel;
	}

	
	// ---------------------------------------------------------------------------------------------------
	// getName()
	// --------------------------------------------------------------------------------------------------- 
	// Returns the characters name
	// ---------------------------------------------------------------------------------------------------
	public string getName()
	{
		return name;
	}

	public void InitialChracters()
	{
		characters = new Character[2];
		for (int i = 0; i < 2; i++)
		{
			characters[i] = new Character();
		}
	}
	public bool isBossStage
	{
		get { return stageNumber % 4 == 0; }
	}

	public void loadNextScene()
	{
		if (isBossStage && BossStages.Count() > 0){
			string nextStage = BossStages.OrderBy(a => Guid.NewGuid()).FirstOrDefault();
			/*int index = System.Random.Next(BossStages.Count);
			String nextStage = BossStages[index];*/
			Application.LoadLevel(nextStage);
			//BossStages.Remove(nextStage);
			stageNumber++;

		}
		else if (!isBossStage && puzzleStages.Count() > 0){
			string nextStage = puzzleStages.OrderBy(a => Guid.NewGuid()).FirstOrDefault();
			/*int index = System.Random.Next(puzzleStages.Count);
			String nextStage = puzzleStages[index];*/
			Application.LoadLevel(nextStage);
			//puzzleStages.Remove(nextStage);
			stageNumber++;
			
		}
		else {
			Application.LoadLevel("lastLevel");
		}
	}
}
