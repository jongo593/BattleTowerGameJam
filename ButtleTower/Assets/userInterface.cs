using UnityEngine;
using System.Collections;

public class userInterface : MonoBehaviour {
	GUIStyle style= null;
//	Texture2D texture = null;
	int maxHP = Screen.width/3;
	//private GUIStyle currentStyle = null;
	

	void OnGUI () 
	{
		Character p1 = gamestate.Instance.characters[0];
		Character p2 = gamestate.Instance.characters[1];

		//InitStyles();
		GUI.Box (new Rect (0, 0, maxHP, 20), "Player 1");
		GUI.Box (new Rect (0, 20, maxHP, 20), gamestate.Instance.characters [0].health.ToString ());

		GUI.Box (new Rect (Screen.width-maxHP, 0, maxHP, 20), "Player 2");
		GUI.Box (new Rect (Screen.width-(maxHP), 20, maxHP, 20), gamestate.Instance.characters [1].health.ToString ());


		/*GUI.Box (new Rect (0, 0, (p1.health / p1.maxHP) * maxHP, 20), " ", style);
		GUI.Box (new Rect (Screen.width - maxHP, 0, (p2.health / p2.maxHP) * maxHP, 20), " ", style);*/
	}

	/*
	private void InitStyles()
	{
		if( currentStyle == null )
		{
			currentStyle = new GUIStyle( GUI.skin.box );
			currentStyle.normal.background = MakeTex( 2, 2, new Color( 0f, 1f, 0f, 0.5f ) );
		}
	}
	
	private Texture2D MakeTex( int width, int height, Color col )
	{
		Color[] pix = new Color[width * height];
		for( int i = 0; i < pix.Length; ++i )
		{
			pix[ i ] = col;
		}
		Texture2D result = new Texture2D( width, height );
		result.SetPixels( pix );
		result.Apply();
		return result;
	}*/


}
