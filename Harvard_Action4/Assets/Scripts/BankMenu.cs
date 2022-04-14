using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankMenu : MonoBehaviour
{
    private GameHandler gameHandler;
    public GameObject bankMenuUI;
    public GameObject item1BuyButton;
	public GameObject buttonOpenBank;

    public double investmentOption1 = 1000;
    //public AudioSource KaChingSFX;

	void Start (){
		bankMenuUI.SetActive(false);
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
	}

	void Update (){
		//checks money amount to show purchasable good selection
		if ((GameHandler.gotMoney >= investmentOption1 && GameHandler.onBank == true)) {
			item1BuyButton.SetActive(true);
		}
		else {
			item1BuyButton.SetActive(false);
		}
	}

	//Button Functions:
	public void Button_OpenShop(){
		bankMenuUI.SetActive(true);
		buttonOpenBank.SetActive(false);
	    Time.timeScale = 0f;
	}

	public void Button_CloseShop() {
	    bankMenuUI.SetActive(false);
	    buttonOpenBank.SetActive(true);
	    Time.timeScale = 1f;
	}
	
	public void Button_InvestOption1(){
		gameHandler.playerInvestMoney(investmentOption1);
		//KaChingSFX.Play();
	}
}
