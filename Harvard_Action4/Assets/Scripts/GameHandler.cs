using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour
{

	//Game Objects
	public GameObject pauseMenuUI;
	private GameObject player;
	public GameObject essenceText;
	public GameObject essenceBankedText;
	public GameObject seedText;
	public GameObject bankMenuUI;

	//Stat Tracker
	public static double heldSeed = 0;
	public static float[] seeds;
	public static double heldEssence = 0;
	public static double bankedEssence = 0;
	public static int playerStat;
	public static bool GameisPaused = false;
	public static bool onBank = false;
	public static bool finalBank = false;
	public static bool sceneChange = false;
	public static bool newGame = true;
	public static Transform pSpawn;
	
	//playerSkills
	public static bool doubleJumpActive = false;
	public static bool seeInvisibleActive = false;

	//bank options
	public static bool OptionOne = false;
	public static bool OptionTwo = false;
	public static bool OptionThree = false;
	public static bool SeedOne = false;
	public static bool SeedTwo = false;
	public static bool SeedThree = false;

	//Audio
	public AudioMixer mixer;
	public static float volumeLevel = 1.0f;
	private Slider sliderVolumeCtrl;

	//Scene Related
	private string sceneName;
	public static string SceneDied = "MainMenu";
    public string NextLevel = "MainMenu";

	void Awake()
	{
		SetLevel(volumeLevel);
		GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
		if (sliderTemp != null)
		{
			sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
			sliderVolumeCtrl.value = volumeLevel;
		}
		
		// resets all seed counter
		if (newGame == true) {
			seeds = new float[600];
			newGame = false;
		}
	}

	void Start()
	{
		player = GameObject.FindWithTag("Player");
		sceneName = SceneManager.GetActiveScene().name;
		updateStatsDisplay();

		string thisLevel = SceneManager.GetActiveScene().name;
		if ((thisLevel != "SceneLose") && (thisLevel != "SceneWin"))
		{
			SceneDied = thisLevel;
		}

		pauseMenuUI.SetActive(false);
		GameisPaused = false;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameisPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}

		if (onBank == true)
		{
			bankMenuUI.SetActive(true);
		}

		else
		{
			bankMenuUI.SetActive(false);
		}
		
		if (sceneChange == true)
		{
			sceneChange = false;
			finalBank = false;
			onBank = false;
			bankedEssence = 0;
			heldEssence = 0;
			Time.timeScale = 1f;
            SceneManager.LoadScene(NextLevel);
		}
	}

	public void playerGetSeed(int seedId)
	{
		double Temp = 1;
		heldSeed += Temp;
		seeds[seedId] = 1;
		updateStatsDisplay();
	}

	public void playerGetEssence(double essence)
	{
		heldEssence += essence;
		updateStatsDisplay();
	}

	public void playerLoseEssence(double essence)
	{
		
		if (heldEssence <= 0)
		{
			playerDies(); //game level resets
		}
		else
        {
			heldEssence -= essence;
			updateStatsDisplay();
		}
	}


	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameisPaused = true;
	}

	public void Resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameisPaused = false;
	}

	public void SetLevel(float sliderValue)
	{
		mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
		volumeLevel = sliderValue;
	}

	public void updateStatsDisplay()
	{
		Text essenceTextTemp = essenceText.GetComponent<Text>();
		essenceTextTemp.text = "Green Essence: " + heldEssence;
		Text bankedEssenceTextTemp = essenceBankedText.GetComponent<Text>();
		bankedEssenceTextTemp.text = "Banked Essence: " + bankedEssence;
		Text seedTextTemp = seedText.GetComponent<Text>();
		seedTextTemp.text = "SEED: " + heldSeed;
	}

	public void playerDies()
	{
		player.GetComponent<PlayerMovement>().playerDead();
		StartCoroutine(DeathPause());
	}

	IEnumerator DeathPause()
	{
		player.GetComponent<PlayerMovement>().isAlive = false;
		yield return new WaitForSeconds(0.5f);
		heldEssence = 0;
		bankedEssence = 0;
		SceneManager.LoadScene("Main Test Scene");
	}

	public void StartGame()
	{
		SceneManager.LoadScene("TutorialLevel");
	}

	public void RestartGame()
	{
		SceneManager.LoadScene("MainMenu");
		//playerHealth = StartPlayerHealth;
	}

	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
	}

	public void Credits()
	{
		SceneManager.LoadScene("Credits");
	}

	public void ReplayGame()
	{
		SceneManager.LoadScene(SceneDied);
	}
	
	public void NewGame() {
		GameHandler.sceneChange = true;
	}
}
