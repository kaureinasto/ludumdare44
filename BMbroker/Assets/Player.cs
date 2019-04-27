using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	int age;
	string playerName;
	
	public int incomeRate;
	
	public int outgoingRate;
	
	public Player(){
		this.age = 216;
		this.playerName = "Roy";
	}
	public void AddAge(int months){
		this.age += months;
	}
	public void RemoveAge(int months){
		this.age -= months;
	}
	public void addIncome(int months){
		this.incomeRate += months;
	}
	public void removeIncome(int months){
		this.incomeRate -= months;
	}
	public float getAge(){
		return this.age;
	}
	
}
