using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	float age;
	string playerName;
	
	public Player(){
		this.age = 18.0f;
		this.playerName = "Roy";
	}
	public void AddAge(float age){
		this.age += age;
	}
	public float getAge(){
		return this.age;
	}
}
