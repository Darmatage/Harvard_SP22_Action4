using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameHandler : MonoBehaviour
{
	public bool isMenu = false;

	//Game Objects
	public GameObject pauseMenuUI;
	private GameObject player;
	private PlayerMovement playerMov;
	private Transform playerPos;
	public GameObject essenceText;
	public GameObject essenceBankedText;
	public GameObject seedText;
	public GameObject GUI;
	public GameObject bankMenuUI;
	public GameObject treeMenuUI;

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
	public static bool onTree = false;
	public static Transform pSpawn;
	public bool isAlive = true;
	
	//tree stage
	public static bool tree0 = true;
	public static bool tree1 = false;
	public static bool tree2 = false;
	public static bool tree3 = false;
	public static bool tree4 = false;
	public static bool tree5 = false;
	
	//playerSkills
	public static bool doubleJumpActive = false;
	public static bool seeInvisibleActive = false;
	public static bool crouchStopWind = false;
	public static bool zoomOut = false;

	//bank options
	public static bool OptionOne = false;
	public static bool OptionTwo = false;
	public static bool OptionThree = false;
	public static bool SeedOne = false;
	public static bool SeedTwo = false;
	public static bool SeedThree = false;
	
	//tree options
	public static bool SeedOptionOne = true;
	public static bool SeedOptionTwo = true;
	public static bool SeedOptionThree = true;
	public static bool SeedOptionFour = true;
	public static bool SeedOptionFive = true;
	public static bool SeedOptionSix = true;

	//Audio
	public AudioMixer mixer;
	public static float volumeLevel = 1.0f;
	private Slider sliderVolumeCtrl;

	//Scene Related
	private string sceneName;
	public static string SceneDied = "MainMenu";
    public string NextLevel = "MainMenu";
	
	//particles
    public GameObject hitParticles;
    public GameObject essenceParticles;
    public GameObject seedParticles;
	
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
		if (isMenu == false) {
			GUI.SetActive(true);
			player = GameObject.FindWithTag("Player");
			playerMov = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
			playerPos = GameObject.FindWithTag("PlayerBottom").GetComponent<Transform>();
		} else {
			GUI.SetActive(false);
		}
		
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
		} else
		{
			bankMenuUI.SetActive(false);
		}
		
		if (onTree == true)
		{
			treeMenuUI.SetActive(true);
		} else
		{
			treeMenuUI.SetActive(false);
		}
		
		if (sceneChange == true)
		{
			sceneChange = false;
			finalBank = false;
			SeedOne = false;
			SeedTwo = false;
			SeedThree = false;
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
		playerGetSeed();
	}

	public void playerGetEssence(double essence)
	{
		heldEssence += essence;
		updateStatsDisplay();
		if (essence > 0) {
			playerGetEssence();
		}
	}

	public void playerLoseEssence(double essence)
	{
		if (heldEssence <= 0)
		{
			// isAlive = false;
			//playerMov.Jump();
			playerHit();
			StartCoroutine(DeathPause());
		}
		else
        {
			heldEssence -= essence;
			updateStatsDisplay();
		}
		playerHit();
	}

	public void playerHit(){
		if (hitParticles != null) {
			GameObject particleSys = Instantiate(hitParticles, playerPos.position, Quaternion.identity);
			StartCoroutine(destroyParticles(particleSys));
		}
    }
	
	public void playerGetEssence(){
		if (essenceParticles != null) {
			GameObject particleSys = Instantiate(essenceParticles, playerPos.position, Quaternion.identity);
			StartCoroutine(destroyParticles(particleSys));
		}
    }
	
	public void playerGetSeed(){
		if (seedParticles != null) {
			GameObject particleSys = Instantiate(seedParticles, playerPos.position, Quaternion.identity);
			StartCoroutine(destroyParticles(particleSys));
		}
    }

    IEnumerator destroyParticles(GameObject pSys)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(pSys);
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
		essenceTextTemp.text = heldEssence.ToString();
		Text bankedEssenceTextTemp = essenceBankedText.GetComponent<Text>();
		bankedEssenceTextTemp.text = bankedEssence.ToString();
		Text seedTextTemp = seedText.GetComponent<Text>();
		seedTextTemp.text = heldSeed + "/50";
	}

	IEnumerator DeathPause()
	{
		yield return new WaitForSeconds(0.5f);
		playerHit();
		heldEssence = 0;
		bankedEssence = 0;
		isAlive = true;
		SceneManager.LoadScene("SceneLose");
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
	
	public void RestartLevel()
	{
		SceneManager.LoadScene("MainHub");
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
		newGame = true;
		heldSeed = 0;
		GameHandler.sceneChange = true;
	}
}
