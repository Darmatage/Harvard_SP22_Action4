using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankIntercations : MonoBehaviour
{
    private GameHandler gameHandler;
    private PlayerMovement player;
	public GameObject BankOpened;
	public GameObject BankClosed;
	public GameObject FinalBankOpened;
	public GameObject FinalBankClosed;
    //public AudioSource KaChingSFX;
	private bool bankOpen = true;
	public bool finalBank = false;
	private bool Option1 = false;
	private bool Option2 = false;
	private bool Option3 = false;
	private bool Seed1 = false;
	private bool Seed2 = false;
	private bool Seed3 = false;
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
		
		if (finalBank == true) {
			Seed1 = true;
			Seed2 = true;
			Seed3 = true;
			BankOpened.SetActive(false);
			BankClosed.SetActive(false);
			FinalBankOpened.SetActive(true);
			FinalBankClosed.SetActive(false);
		}
		else {
			Option1 = true;
			Option2 = true;
			Option3 = true;
			BankOpened.SetActive(true);
			BankClosed.SetActive(false);
			FinalBankOpened.SetActive(false);
			FinalBankClosed.SetActive(false);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {	
		GameHandler.onBank = true;
		player.checkpoint.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);;
		
        if (other.gameObject.tag == "Player" && bankOpen == true)
        {
			bankOpen = false;
			GameHandler.heldEssence += GameHandler.bankedEssence * 0.5;
			
			
			if (finalBank == true) {
				BankOpened.SetActive(false);
				BankClosed.SetActive(false);
				FinalBankOpened.SetActive(false);
				FinalBankClosed.SetActive(true);
				GameHandler.finalBank = true;
				GameHandler.heldEssence += GameHandler.bankedEssence;
				GameHandler.bankedEssence = 0;
				//Time.timeScale = 0f;
			} else {
				BankOpened.SetActive(false);
				BankClosed.SetActive(true);
				FinalBankOpened.SetActive(false);
				FinalBankClosed.SetActive(false);
			}
			
			gameHandler.updateStatsDisplay();
		}
			
		
		if (other.gameObject.tag == "Player") {
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
