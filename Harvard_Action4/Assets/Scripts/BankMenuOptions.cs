using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankMenuOptions : MonoBehaviour
{
    private GameHandler gameHandler;
    public double e1 = 1000;
	public double e2 = 5000;
	public double e3 = 10000;
	public double s1 = 1000;
	public double s2 = 5000;
	public double s3 = 10000;
	public GameObject Option1;
	public GameObject Option2;
	public GameObject Option3;
	public GameObject Seed1;
	public GameObject Seed2;
	public GameObject Seed3;
	private bool Seed1Have = true;
	private bool Seed2Have = true;
	private bool Seed3Have = true;
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
	}
	
	void Update (){
		if (GameHandler.onBank == true) {
			//checks money amount to show purchasable good selection
			if (GameHandler.heldEssence >= e1 && GameHandler.OptionOne == true) {
				Option1.SetActive(true);
			}
			else {
				Option1.SetActive(false);
			}
			
			if (GameHandler.heldEssence >= e2 && GameHandler.OptionTwo == true) {
				Option2.SetActive(true);
			}
			else {
				Option2.SetActive(false);
			}
			
			if (GameHandler.heldEssence >= e3 && GameHandler.OptionThree == true) {
				Option3.SetActive(true);
			}
			else {
				Option3.SetActive(false);
			}
			
			if (GameHandler.heldEssence >= s1 && GameHandler.SeedOne == true && Seed1Have == true) {
				Seed1.SetActive(true);
			}
			else {
				Seed1.SetActive(false);
			}
			
			if (GameHandler.heldEssence >= s2 && GameHandler.SeedTwo == true && Seed2Have == true) {
				Seed2.SetActive(true);
			}
			else {
				Seed2.SetActive(false);
			}
			
			if (GameHandler.heldEssence >= s3 && GameHandler.SeedThree == true && Seed3Have == true) {
				Seed3.SetActive(true);
			}
			else {
				Seed3.SetActive(false);
			}
		}
		//reset seed selection on new level
	}
	
	public void button_Option1(){
		playerInvestEssence(e1);
	}
	
	public void button_Option2(){
		playerInvestEssence(e2);
	}
	
	public void button_Option3(){
		playerInvestEssence(e3);
	}
	
	public void button_Seed1(){
		playerBuySeed(s1);
		Seed1Have = false;
	}
	
	public void button_Seed2(){
		playerBuySeed(s2);
		Seed2Have = false;
	}
	
	public void button_Seed3(){
		playerBuySeed(s3);
		Seed3Have = false;
	}
	
	public void playerInvestEssence(double essence){
		GameHandler.heldEssence -= essence;
		GameHandler.bankedEssence += essence;
		gameHandler.updateStatsDisplay();
	}
	
	public void playerBuySeed(double essence){
		GameHandler.heldEssence -= essence;
		GameHandler.heldSeed += 1;
		gameHandler.updateStatsDisplay();
	}
	
	public void Button_CloseBank() {
		GameHandler.onBank = false;
		GameHandler.OptionOne = false;
		GameHandler.OptionTwo = false;
		GameHandler.OptionThree = false;
		GameHandler.SeedOne = false;
		GameHandler.SeedTwo = false;
		GameHandler.SeedThree = false;
	}
}