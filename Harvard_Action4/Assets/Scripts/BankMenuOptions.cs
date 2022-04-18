using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankMenuOptions : MonoBehaviour
{
    private GameHandler gameHandler;
    public double EssenceOptionOne = 1000;
    public GameObject optionOneBuyButton;
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
	}
	
	void Update (){
		//checks money amount to show purchasable good selection
		if (GameHandler.heldEssence >= EssenceOptionOne && GameHandler.OptionOne == true) {
			optionOneBuyButton.SetActive(true);
		}
		else {
			optionOneBuyButton.SetActive(false);
		}
	}
	
	public void Button_InvestEssenceOptionOne(){
		gameHandler.playerInvestEssence(EssenceOptionOne);
		//KaChingSFX.Play();
	}
	
	public void Button_CloseBank() {
		GameHandler.onBank = false;
		GameHandler.OptionOne = false;
	}
}