using UnityEngine;
using System.Collections;

public class Boss : Character {

	// Use this for initialization
	public Boss(int ArmorRating,int baseAttack)
	{
		armor = ArmorRating;
		unarmed = baseAttack;
	}
}
