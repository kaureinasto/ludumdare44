using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	int age;
	string playerName;
	
	public int incomeRate;
	
	public int outgoingRate;
	
	public ArrayList ownedItems;
	public Player(){
		this.age = 216;
		this.playerName = "Roy";
		this.outgoingRate = 0;
		this.incomeRate = 1;
		this.ownedItems = new ArrayList();
	}
	public void AddAge(int months){
		this.age += months;
	}
	public void purchaseProperty(OwnableItem item){
		this.ownedItems.Add(item);
		this.incomeRate += item.incomingRate;
		this.outgoingRate -= item.outgoingRate;
		this.age -= item.value;
	}
	public void sellProperty(OwnableItem item){
		this.ownedItems.Remove(item);
		this.incomeRate -= item.incomingRate;
		this.outgoingRate += item.outgoingRate;
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
	public int getIncome(){
		return this.incomeRate;
	}
	public int getOutgoing(){
		return this.outgoingRate;
	}

	public float getAge(){
		return this.age;
	}
	
}
