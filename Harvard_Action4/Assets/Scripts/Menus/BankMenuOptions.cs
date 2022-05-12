using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	public GameObject bankTitle;
	public GameObject finalBankTitle;
	public GameObject closeOption;
	
	public int bankNo;
	private bool Seed1Have;
	private bool Seed2Have;
	private bool Seed3Have;
	private static bool Seed01Have = true;
	private static bool Seed02Have = true;
	private static bool Seed03Have = true;
	private static bool Seed11Have = true;
	private static bool Seed12Have = true;
	private static bool Seed13Have = true;
	private static bool Seed21Have = true;
	private static bool Seed22Have = true;
	private static bool Seed23Have = true;
	private static bool Seed31Have = true;
	private static bool Seed32Have = true;
	private static bool Seed33Have = true;
	private static bool Seed41Have = true;
	private static bool Seed42Have = true;
	private static bool Seed43Have = true;
	
    public string NextLevel = "MainMenu";
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		if (bankNo == 0) {
			Seed1Have = Seed01Have;
			Seed2Have = Seed02Have;
			Seed3Have = Seed03Have;
		} else if (bankNo == 1) {
			Seed1Have = Seed11Have;
			Seed2Have = Seed12Have;
			Seed3Have = Seed13Have;
		} else if (bankNo == 2) {
			Seed1Have = Seed21Have;
			Seed2Have = Seed22Have;
			Seed3Have = Seed23Have;
		} else if (bankNo == 3) {
			Seed1Have = Seed31Have;
			Seed2Have = Seed32Have;
			Seed3Have = Seed33Have;
		} else if (bankNo == 4) {
			Seed1Have = Seed41Have;
			Seed2Have = Seed42Have;
			Seed3Have = Seed43Have;
		}
	}
	
	void Update (){
		
		if (bankNo == 0) {
			Seed01Have = Seed1Have;
			Seed02Have = Seed2Have;
			Seed03Have = Seed3Have;
		} else if (bankNo == 1) {
			Seed11Have = Seed1Have;
			Seed12Have = Seed2Have;
			Seed13Have = Seed3Have;
		} else if (bankNo == 2) {
			Seed21Have = Seed1Have;
			Seed22Have = Seed2Have;
			Seed23Have = Seed3Have;
		} else if (bankNo == 3) {
			Seed31Have = Seed1Have;
			Seed32Have = Seed2Have;
			Seed33Have = Seed3Have;
		} else if (bankNo == 4) {
			Seed41Have = Seed1Have;
			Seed42Have = Seed2Have;
			Seed43Have = Seed3Have;
		}
		
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
			if (GameHandler.finalBank == true) {
				closeOption.SetActive(true);
				finalBankTitle.SetActive(true);
				bankTitle.SetActive(false);
			}
			else {
				closeOption.SetActive(false);
				bankTitle.SetActive(true);
				finalBankTitle.SetActive(false);
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
		if (GameHandler.finalBank == true) {
            GameHandler.sceneChange = true;
		}
	}
}