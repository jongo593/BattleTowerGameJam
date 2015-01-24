using UnityEngine;
using System.Collections;

public class levelgui : MonoBehaviour {

	// Initialize level
	void Start () 
	{
		print ("Loaded: " + gamestate.Instance.getLevel());
	}
	
	
	
	// ---------------------------------------------------------------------------------------------------
	// OnGUI()
	// --------------------------------------------------------------------------------------------------- 
	// Provides a GUI on level scenes
	// ---------------------------------------------------------------------------------------------------
	void OnGUI()
	{	
		{
			int curLevel = gamestate.Instance.getLevel();
			// Create buttons to move between level 1 and level 2
			if (GUI.Button (new Rect (30, 30, 150, 30), "Load Level 1"))
			{
				print ("Moving to level "+curLevel+1.ToString());
				gamestate.Instance.setLevel(curLevel+1);
				Application.LoadLevel("level"+(curLevel+1));
			}
			
			if (GUI.Button (new Rect (300, 30, 150, 30), "Load Level 2"))
			{
				print ("Moving to level "+curLevel+1.ToString());
				gamestate.Instance.setLevel(curLevel+1);
				Application.LoadLevel("level"+(curLevel+1));
			}		
			
			// Output stats
			GUI.Label(new Rect(30, 100, 400, 30), "Name: " + gamestate.Instance.getName());
			GUI.Label(new Rect(30, 130, 400, 30), "HP: " + gamestate.Instance.getHP().ToString());
			GUI.Label(new Rect(30, 160, 400, 30), "MP: " + gamestate.Instance.getMP().ToString());
		
		}
	}
}
