using UnityEngine;
using System.Collections;

public class Character {

	public int initHealth = 100;
	public int armor = 0;
	public int damageTaken = 0;
	public bool isAttacking = false;
	public int health
	{
		get{ return (initHealth + armor*50) - damageTaken;}
	}
	public int unarmed = 25;

	public int maxHP
	{
		get {return (initHealth + armor*50);}
	}

	public bool inv = false;
	//public Weapon weapon = null;
	public bool isDead
	{
		get { return (health <= 0); }
	}
	public int weapon = 0;
	public int attack
	{
		get { return unarmed + ( weapon * unarmed); }//TODO set initial value;
	}
	public void takeDamage(int amount)
	{
		damageTaken += amount;
	}
	public void attackChracter (Character opponent)
	{
		opponent.takeDamage (attack);
	}



}
