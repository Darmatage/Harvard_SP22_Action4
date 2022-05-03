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
	private float gameTimer = 20f;

	void Start(){
		//assign the length of the array to the end of the random range
		rangeEnd = spawnPoints.Length - 1 ;
		player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
	}

	void FixedUpdate(){
		Debug.Log(gameTimer);
		//timer
		gameTimer += Time.deltaTime;
		
		if (gameTimer <= 20f || gameTimer >= 15f){
			if (singleDirection == true || multiDirection == true) {
				player.WindMoveLeft();
			}
		}
		
		if (gameTimer <= 10f || gameTimer >= 5f){
			if (singleDirection == true) {
				player.WindMoveLeft();
			}
			if (multiDirection == true) {
				player.WindMoveRight();
			}
		}
		
		if (gameTimer >= 20f){
			gameTimer = 0f;
			StartCoroutine(SpawnWind());
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
	  
	  void spawnLeft(){
			spawnWindCurve();
			spawnWindCircle();
			spawnWindCurve();
			spawnWindCircle();
	  }
	  void spawnRight(){
			spawnWindCurve();
			spawnWindCircle();
			spawnWindCurve();
			spawnWindCircle();
	  }
	  
	IEnumerator SpawnWind(){
		if (singleDirection == true) {
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			yield return new WaitForSeconds(6f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
		}
		if (multiDirection == true) {
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(1f);
			spawnLeft();
			yield return new WaitForSeconds(6f);
			spawnRight();
			yield return new WaitForSeconds(1f);
			spawnRight();
			yield return new WaitForSeconds(1f);
			spawnRight();
			yield return new WaitForSeconds(1f);
			spawnRight();
			yield return new WaitForSeconds(1f);
			spawnRight();
		}
	}
}
