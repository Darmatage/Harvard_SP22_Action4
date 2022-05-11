using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BankIntercations : MonoBehaviour
{
    private GameHandler gameHandler;
    private PlayerMovement playerMov;
	public GameObject BankOpened;
	public GameObject BankClosed;
	public GameObject FinalBankOpened;
	public GameObject FinalBankClosed;
    //public AudioSource KaChingSFX;
	private bool bankOpen = true;
	public bool finalBank = false;
	private bool Option1 = true;
	private bool Option2 = true;
	private bool Option3 = true;
	private bool Seed1 = false;
	private bool Seed2 = false;
	private bool Seed3 = false;
	private double temp;
	
	//temp
    public string NextLevel = "MainHub";
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        playerMov = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
		
		if (finalBank == true) {
			Seed1 = true;
			Seed2 = true;
			Seed3 = true;
			Option1 = false;
			Option2 = false;
			Option3 = false;
			BankOpened.SetActive(false);
			BankClosed.SetActive(false);
			FinalBankOpened.SetActive(true);
			FinalBankClosed.SetActive(false);
		} else {
			Seed1 = false;
			Seed2 = false;
			Seed3 = false;
			Option1 = true;
			Option2 = true;
			Option3 = true;
			BankOpened.SetActive(true);
			BankClosed.SetActive(false);
			FinalBankOpened.SetActive(false);
			FinalBankClosed.SetActive(false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (gameHandler != null) {
			GameHandler.onBank = true;
		} else {
			Debug.Log("onBank is null");
		}
		
		if (other != null) {
			
			if (other.gameObject.tag == "Player"){
					
				if (bankOpen == true) {
					// Debug.Log("Bank closed");
					bankOpen = false;
					gameHandler.playerGetEssence(GameHandler.bankedEssence * 0.5);
					
					if (finalBank == true) {
						// Debug.Log("Swap image Final");
						BankOpened.SetActive(false);
						BankClosed.SetActive(false);
						FinalBankOpened.SetActive(false);
						FinalBankClosed.SetActive(true);
						GameHandler.finalBank = true;
						gameHandler.playerGetEssence(GameHandler.bankedEssence);
						GameHandler.bankedEssence = 0;
						//Time.timeScale = 0f;
					} else {
						// Debug.Log("Swap image");
						BankOpened.SetActive(false);
						BankClosed.SetActive(true);
						FinalBankOpened.SetActive(false);
						FinalBankClosed.SetActive(false);
					}
					
					gameHandler.updateStatsDisplay();
				}
					
				if (Option1 == true) {
					GameHandler.OptionOne = true;
				}
				if (Option2 == true) {
					GameHandler.OptionTwo = true;
				}
				if (Option3 == true) {
					GameHandler.OptionThree = true;
				}
				if (Seed1 == true) {
					GameHandler.SeedOne = true;
				}
				if (Seed2 == true) {
					GameHandler.SeedTwo = true;
				}
				if (Seed3 == true) {
					GameHandler.SeedThree = true;
				}
			}
		} else {
			Debug.Log("other is null");
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GameHandler.onBank = false;
			GameHandler.OptionOne = false;
			GameHandler.OptionTwo = false;
			GameHandler.OptionThree = false;
			GameHandler.SeedOne = false;
			GameHandler.SeedTwo = false;
			GameHandler.SeedThree = false;
			Time.timeScale = 1f;
			bankOpen = false;
		}
	}
}
