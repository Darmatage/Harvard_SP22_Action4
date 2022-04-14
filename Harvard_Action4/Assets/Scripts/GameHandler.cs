using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour {

	  public static int playerStat;

      public static bool GameisPaused = false;
      public GameObject pauseMenuUI;
      public AudioMixer mixer;
      public static float volumeLevel = 1.0f;
      private Slider sliderVolumeCtrl;

      private GameObject player;
      //public static int playerHealth = 100;
      //public int StartPlayerHealth = 100;
      //public GameObject healthText;

      public static double gotMoney = 0;
	  public static double gotInvestment = 0;
      public GameObject moneyText;
	  public GameObject investText;
	  public GameObject buttonOpenBank;

      public bool isDefending = false;

      public static bool stairCaseUnlocked = false;
      //this is a flag check. Add to other scripts: GameHandler.stairCaseUnlocked = true;

      private string sceneName;

      public static string SceneDied = "MainMenu";

	  public static bool onBank;

	  void Awake (){
		  SetLevel (volumeLevel);
				GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
					sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                    sliderVolumeCtrl.value = volumeLevel;
                }
      }

      void Start(){
		  player = GameObject.FindWithTag("Player");
          sceneName = SceneManager.GetActiveScene().name;
          //if (sceneName=="MainMenu"){ //uncomment these two lines when the MainMenu exists
          //      playerHealth = StartPlayerHealth;
          //}
          updateStatsDisplay();

          string thisLevel = SceneManager.GetActiveScene().name;
          if ((thisLevel != "SceneLose") && (thisLevel != "SceneWin")){
               SceneDied = thisLevel;
          }

		  pauseMenuUI.SetActive(false);
          GameisPaused = false;
		  onBank = false;
      }

	  void Update (){
		  if (Input.GetKeyDown(KeyCode.Escape)){
			  if (GameisPaused){
				  Resume();
			  }
              else{
				  Pause();
              }
          }

		if (onBank == true){
			buttonOpenBank.SetActive(true);
		}
		else {
			buttonOpenBank.SetActive(false);
		}

	}

	  public void playerInvestMoney(double money){
		  gotMoney -= money;
		  gotInvestment += money;
		  updateStatsDisplay();
      }

	  public void playerGetMoney(double money){
		  gotMoney += money;
		  updateStatsDisplay();
      }

      //public void playerGetHit(int damage){
      //     if (isDefending == false){
      //            playerHealth -= damage;
      //            if (playerHealth >=0){
      //                  updateStatsDisplay();
      //            }
      //            player.GetComponent<PlayerHurt>().playerHit();
       //     }

      //     if (playerHealth >= StartPlayerHealth){
       //           playerHealth = StartPlayerHealth;
      //      }

      //     if (playerHealth <= 0){
      //            playerHealth = 0;
      //            playerDies();
      //      }
      //}
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameisPaused = true;
		}

    public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameisPaused = false;
	}

    public void SetLevel (float sliderValue){
		mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
		volumeLevel = sliderValue;
    }

      public void updateStatsDisplay(){
            //Text healthTextTemp = healthText.GetComponent<Text>();
            //healthTextTemp.text = "HEALTH: " + playerHealth;

            Text moneyTextTemp = moneyText.GetComponent<Text>();
            moneyTextTemp.text = "MONEY: " + gotMoney;
			Text investTextTemp = investText.GetComponent<Text>();
            investTextTemp.text = "Investment: " + gotInvestment;
      }

      public void playerDies(){
            player.GetComponent<PlayerHurt>().playerDead();
            StartCoroutine(DeathPause());
      }

      IEnumerator DeathPause(){
            player.GetComponent<PlayerMove>().isAlive = false;
            player.GetComponent<PlayerJump>().isAlive = false;
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene("EndLose");
      }

      public void StartGame() {
            SceneManager.LoadScene("Main Test Scene");
      }

      public void RestartGame() {
            SceneManager.LoadScene("MainMenu");
            //playerHealth = StartPlayerHealth;
      }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

      public void Credits() {
            SceneManager.LoadScene("Credits");
      }

      public void ReplayGame (){
           SceneManager.LoadScene(SceneDied);
      }
}
