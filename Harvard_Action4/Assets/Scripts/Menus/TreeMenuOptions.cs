using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeMenuOptions : MonoBehaviour
{
    private GameHandler gameHandler;
    public double sd1 = 5;
	public double sd2 = 15;
	public double sd3 = 25;
	public double sd4 = 35;
	public double sd5 = 45;
	public double sd6 = 50;
	public GameObject Option1;
	public GameObject Option2;
	public GameObject Option3;
	public GameObject Option4;
	public GameObject Option5;
	public GameObject Option6;
	public GameObject Select1;
	public GameObject Select2;
	public GameObject Select3;
	public GameObject Select4;
	public GameObject Select5;
	public GameObject Select6;
	
	void Start (){
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		Select1.SetActive(false);
		Select2.SetActive(false);
		Select3.SetActive(false);
		Select4.SetActive(false);
		Select5.SetActive(false);
		Select6.SetActive(false);
	}
	
	void Update (){
		if (GameHandler.onTree == true) {
			//checks money amount to show purchasable good selection
			if (GameHandler.SeedOptionOne == true) {
				Option1.SetActive(true);
				Select1.SetActive(true);
			}
			else {
				Option1.SetActive(false);
			}
			
			if (GameHandler.SeedOptionTwo == true) {
				Option2.SetActive(true);
				Select2.SetActive(true);
			}
			else {
				Option2.SetActive(false);
			}
			
			if (GameHandler.SeedOptionThree == true) {
				Option3.SetActive(true);
				Select3.SetActive(true);
			}
			else {
				Option3.SetActive(false);
			}
			
			if (GameHandler.SeedOptionFour == true) {
				Option4.SetActive(true);
				Select4.SetActive(true);
			}
			else {
				Option4.SetActive(false);
			}
			
			if (GameHandler.SeedOptionFive == true) {
				Option5.SetActive(true);
				Select5.SetActive(true);
			}
			else {
				Option5.SetActive(false);
			}
			
			if (GameHandler.SeedOptionSix == true) {
				Option6.SetActive(true);
				Select6.SetActive(true);
			}
			else {
				Option6.SetActive(false);
			}
		}
		//reset seed selection on new level
	}
	
	public void button_Seed_Option1(){
		if (GameHandler.heldSeed >= sd1){
			GameHandler.SeedOptionOne = false;
			GameHandler.SeedOptionThree = true;
			GameHandler.tree0 = false;
			GameHandler.tree1 = true;
			GameHandler.doubleJumpActive = true;
			FindObjectOfType<AudioManager>().StopAll();
			FindObjectOfType<AudioManager>().Play("Level1");
			//show tutorial
			//sfx grow tree
			//particle effect grow tree
		}
	}
	
	public void button_Seed_Option2(){
		if (GameHandler.heldSeed >= sd2){
			GameHandler.SeedOptionTwo = false;
			GameHandler.SeedOptionFour = true;
			GameHandler.tree1 = false;
			GameHandler.tree2 = true;
			GameHandler.seeInvisibleActive = true;
			FindObjectOfType<AudioManager>().StopAll();
			FindObjectOfType<AudioManager>().Play("Level2");
			//show tutorial
			//sfx grow tree
			//particle effect grow tree
		}
	}
	
	public void button_Seed_Option3(){
		if (GameHandler.heldSeed >= sd3){
			GameHandler.SeedOptionThree = false;
			GameHandler.SeedOptionFive = true;
			GameHandler.tree2 = false;
			GameHandler.tree3 = true;
			GameHandler.crouchStopWind = true;
			FindObjectOfType<AudioManager>().StopAll();
			FindObjectOfType<AudioManager>().Play("Level3");
			//show tutorial
			//sfx grow tree
			//particle effect grow tree
		}		
	}
	
	public void button_Seed_Option4(){
		if (GameHandler.heldSeed >= sd4){
			GameHandler.SeedOptionFour = false;
			GameHandler.SeedOptionSix = true;
			GameHandler.tree3 = false;
			GameHandler.tree4 = true;
			GameHandler.zoomOut = true;
			FindObjectOfType<AudioManager>().StopAll();
			FindObjectOfType<AudioManager>().Play("Level4");
			//show tutorial
			//sfx grow tree
			//particle effect grow tree
		}
	}
	
	public void button_Seed_Option5(){
		if (GameHandler.heldSeed >= sd5){
			GameHandler.SeedOptionFive = false;
			GameHandler.tree4 = false;
			GameHandler.tree5 = true;
			FindObjectOfType<AudioManager>().StopAll();
			FindObjectOfType<AudioManager>().Play("MainTheme");
			//show how to finish the game 
			//sfx grow tree
			//particle effect grow tree
		}
	}
	
	public void button_Seed_Option6(){
		if (GameHandler.heldSeed >= sd6){
			GameHandler.SeedOptionSix = false;
			GameHandler.tree5 = false;
			GameHandler.onTree = false;
			SceneManager.LoadScene("SceneWin");
			//background change? 
			//show congrats to finial 
			//particle effect grow tree
		}
	}
}