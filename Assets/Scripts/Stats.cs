﻿using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public int health,maxHealth,damage,speed,wisdom,attackSpeed;
	void Start()
	{
		maxHealth = 100;
		health = maxHealth;
		damage = 3;
		speed = 3;
		wisdom = 3;
	}

}
