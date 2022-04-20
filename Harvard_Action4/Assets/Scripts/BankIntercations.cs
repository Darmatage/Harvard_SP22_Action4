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
	private bool Option1 = true;
	private bool Option2 = true;
	private bool Option3 = true;
	private bool Seed1 = false;
	private bool Seed2 = false;
	private bool Seed3 = false;
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		BankOpened.SetActive(true);
		BankClosed.SetActive(false);
		
		if (finalBank == true) {
			Seed1 = true;
			Seed2 = true;
			Seed3 = true;
			Option1 = false;
			Option2 = false;
			Option3 = false;
		}
		else {
			Seed1 = false;
			Seed2 = false;
			Seed3 = false;
			Option1 = true;
			Option2 = true;
			Option3 = true;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && bankOpen == true)
        {
			Time.timeScale = 0f;
			bankOpen = false;
			GameHandler.onBank = true;
			BankOpened.SetActive(false);
			BankClosed.SetActive(true);
			GameHandler.heldEssence += GameHandler.bankedEssence * 0.5;
			if (finalBank == true) {
				GameHandler.heldEssence += GameHandler.bankedEssence;
				GameHandler.bankedEssence = 0;
			}
			gameHandler.updateStatsDisplay();
			
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
}
