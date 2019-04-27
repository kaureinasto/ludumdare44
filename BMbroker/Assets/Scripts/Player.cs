using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	int age;
	public string playerName;
	ObservableFloat playerAge;
	ObservableFloat playerIncoming;
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
	public void purchaseProperty(ItemData itemData){
		this.ownedItems.Add(itemData);
		this.incomeRate += itemData.incomingRate;
		this.outgoingRate -= itemData.outgoingRate;
		this.age -= itemData.value;
	}
	public void sellProperty(ItemData itemData){
		this.ownedItems.Remove(itemData);
		this.incomeRate -= itemData.incomingRate;
		this.outgoingRate += itemData.outgoingRate;
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
