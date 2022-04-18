using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankIntercations : MonoBehaviour
{
   private GameHandler gameHandler;
	public GameObject BankOpened;
	public GameObject BankClosed;
    //public AudioSource KaChingSFX;
	public bool bankOpen = true;
	public bool finalBank = false;
	public bool Option1 = true;
	
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
			bankOpen = false;
			BankOpened.SetActive(false);
			BankClosed.SetActive(true);
			GameHandler.OptionOne = true;
			Time.timeScale = 0f;
			GameHandler.heldEssence += GameHandler.bankedEssence * 0.5;
			gameHandler.updateStatsDisplay();
        }
    }
}
