using UnityEngine;
using System.Collections;

public class CharacterClass {

	public int initHealth = 100;
	public int armor = 0;
	public int damageTaken = 0;
	public int health
	{
		get{ return (initHealth + armor*50) - damageTaken;}
	}
	public bool inv = false;
	public WeaponClass weapon = null;
	public bool isDead
	{
		get { return (health <= 0);}
	}
}
