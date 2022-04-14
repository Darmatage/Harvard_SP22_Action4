using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankFunctions : MonoBehaviour
{
    private GameHandler gameHandler;
	public GameObject BankOpened;
	public GameObject BankClosed;
	public bool bankOpen = true;
	
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		BankOpened.SetActive(true);
		BankClosed.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && bankOpen == true)
        {
            GameHandler.onBank = true;
			GameHandler.gotMoney += GameHandler.gotInvestment * 0.5;
			gameHandler.updateStatsDisplay();
        }
    }
	
	void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameHandler.onBank = false;
            CloseBank();
        }
    }
	
	public void CloseBank (){
		BankOpened.SetActive(false);
		BankClosed.SetActive(true);
		bankOpen = false;
	}
}
