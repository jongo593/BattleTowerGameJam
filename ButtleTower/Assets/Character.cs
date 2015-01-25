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
	public bool inv = false;
	public Weapon weapon = null;
	public bool isDead
	{
		get { return (health <= 0); }
	}
	public int attack
	{
		get { return weapon != null? weapon.attack : 25; }//TODO set initial value;
	}
	public void takeDamage(int amount)
	{
		damageTaken += amount;
	}
	public void attackChracter (Character opponent)
	{
		opponent.takeDamage (weapon.attack);
	}



}
