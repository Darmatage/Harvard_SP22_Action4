using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankMenu : MonoBehaviour
{
    public GameHandler gameHandler;
    public static bool ShopisOpen = false;
    public GameObject shopMenuUI;
    public GameObject buttonOpenShop;

    public GameObject item1BuyButton;

    public int item1Cost = 1000;
    //public AudioSource KaChingSFX;

	void Start (){
		shopMenuUI.SetActive(false);
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
	}

	void Update (){
		if ((GameHandler.gotMoney >= item1Cost) && (GameHandler.gotitem1 == false)) {item1BuyButton.SetActive(true);}
		else { item1BuyButton.SetActive(false);}
	}

	//Button Functions:
	public void Button_OpenShop(){
		shopMenuUI.SetActive(true);
		buttonOpenShop.SetActive(false);
		ShopisOpen = true;
	    Time.timeScale = 0f;
	}

	public void Button_CloseShop() {
	    shopMenuUI.SetActive(false);
	    buttonOpenShop.SetActive(true);
	    ShopisOpen = false;
	    Time.timeScale = 1f;
	}

	public void Button_BuyItem1(){
		gameHandler.playerGetMoney((item1Cost * -1));
		GameHandler.gotitem1 = true;
		//KaChingSFX.Play();
	}
}
