using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankFunctions : MonoBehaviour
{
    private GameHandler gameHandler;
    public GameObject bankMenuUI;
	public GameObject BankOpened;
	public GameObject BankClosed;
    //public AudioSource KaChingSFX;
	public bool bankOpen = true;
	public bool onBank = false;
	public bool finalBank = false;
	public bool Option1 = true;
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		bankMenuUI.SetActive(false);
	}

	void Update (){
		//checks money amount to show purchasable good selection
		if (onBank == true && Option1 == true) {
			GameHandler.OptionOne = true;
		}
		else {
			GameHandler.OptionOne = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && bankOpen == true)
        {
			onBank = true;
			bankOpen = false;
			bankMenuUI.SetActive(true);
			Time.timeScale = 0f;
			GameHandler.heldEssence += GameHandler.bankedEssence * 0.5;
			gameHandler.updateStatsDisplay();
        }
    }
	
	public void Button_CloseShop() {
	    bankMenuUI.SetActive(false);
		BankOpened.SetActive(false);
		BankClosed.SetActive(true);
		onBank = false;
	    Time.timeScale = 1f;
	}
}
