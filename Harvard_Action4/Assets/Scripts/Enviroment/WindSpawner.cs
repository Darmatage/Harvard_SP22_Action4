using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawner : MonoBehaviour
{
	//Object variables
	public GameObject windCurve;
	public GameObject windCircle;
	public Transform[] spawnPoints;
	private int rangeEnd;
	private Transform spawnPoint;
	private PlayerMovement player;

	//Timing variables
	public bool singleDirection = false;
	public bool multiDirection = false;
	public float spawnRangeStart = 0.5f;
	public float spawnRangeEnd = 1.2f;
	private float timeToSpawn;
	private bool spawning = false;

	public int gameTime = 20;
	private float gameTimer = 0f;

	void Start(){
		//assign the length of the array to the end of the random range
		rangeEnd = spawnPoints.Length - 1 ;
		player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
	}

	void FixedUpdate(){
		Debug.Log(gameTime);
		
		//timer
		gameTimer += 0.01f;
		if (gameTimer >= 1f){
			gameTime -= 1;
			gameTimer = 0;
		}
		
		if (gameTime == 20){
			if (spawning == false) {
				spawning = true;
				//Debug.Log("spawn");
				spawnWindCurve();
				spawnWindCircle();
			}
		}
		
		if (gameTime <= 15 || gameTime >= 10){
			if (singleDirection == true || multiDirection == true) {
				player.WindMoveLeft();
				//Debug.Log("Moving left");
			}
			spawning = false;
		}
		
		if (gameTime == 10){
			if (singleDirection == true) {
				spawnWindCurve();
				spawnWindCircle();
				spawnWindCurve();
				spawnWindCircle();
				spawnWindCurve();
				spawnWindCircle();
				spawnWindCurve();
				spawnWindCircle();
			}
			if (multiDirection == true) {
				spawnWindCurve();
				spawnWindCircle();
				spawnWindCurve();
				spawnWindCircle();
				spawnWindCurve();
				spawnWindCircle();
				spawnWindCurve();
				spawnWindCircle();
			}
		}
		
		if (gameTime <= 5 || gameTime >= 0){
			if (singleDirection == true) {
				player.WindMoveLeft();
			}
			if (multiDirection == true) {
				player.WindMoveRight();
			}
			spawning = false;
		}
		
		if (gameTime <= 0){
			gameTime = 20;
		}
      }

      void spawnWindCurve(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPoints[SPnum];
            Instantiate(windCurve, spawnPoint.position, Quaternion.identity);
      }
	  
      void spawnWindCircle(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPoints[SPnum];
            Instantiate(windCircle, spawnPoint.position, Quaternion.identity);
      }
}
