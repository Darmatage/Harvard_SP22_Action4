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
	public bool Option2 = true;
	public bool Option3 = true;
	public bool Seed1 = false;
	public bool Seed2 = false;
	public bool Seed3 = false;
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		BankOpened.SetActive(true);
		BankClosed.SetActive(false);
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
