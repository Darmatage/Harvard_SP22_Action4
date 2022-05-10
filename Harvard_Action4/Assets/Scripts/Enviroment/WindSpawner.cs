using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSpawner : MonoBehaviour
{
	//Object variables
	public GameObject windCurve;
	public GameObject windCircle;
	public Transform[] spawnPointsL;
	public Transform[] spawnPointsR;
	public Transform[] windTurnPoints;
	private int rangeEnd;
	private Transform spawnPoint;
	private PlayerMovement player;
    private Transform PlayerPos;

	//Timing variables
	public bool singleDirection = false;
	public bool multiDirection = false;
	public float windMod = 0.75f;
	private bool windLeft = false;
	private float gameTimer = 10f;

	void Start(){
		//assign the length of the array to the end of the random range
		rangeEnd = spawnPointsL.Length - 1 ;
		player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
		PlayerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	void Update(){
	}

	void FixedUpdate(){
		//timer
		gameTimer += Time.deltaTime;
		
		if (player.isCrouching == false) {
			if (gameTimer <= 10f && gameTimer >= 9f){
				player.windMove = new Vector3(0f, 0.0f, 0.0f);
			}
			if (gameTimer <= 9f && gameTimer >= 6f){
				if (windLeft == false) {
					if (singleDirection || multiDirection) {
						player.windMove = new Vector3(-windMod, 0.0f, 0.0f);
					}
				}
				if (windLeft == true) {
					if (singleDirection || multiDirection) {
						player.windMove = new Vector3(windMod, 0.0f, 0.0f);
					}
				}
			}
			if (gameTimer <= 6f && gameTimer >= 0f){
				player.windMove = new Vector3(0f, 0.0f, 0.0f);
			}
		} else {
			player.windMove = new Vector3(0f, 0.0f, 0.0f);
		}
		
		if (gameTimer >= 10f){
			gameTimer = 0f;
			if (multiDirection == true) {
				if (PlayerPos.position.y >= windTurnPoints[0].position.y && PlayerPos.position.y <= windTurnPoints[1].position.y){
					windLeft = true;
				}
				if (PlayerPos.position.y >= windTurnPoints[1].position.y && PlayerPos.position.y <= windTurnPoints[2].position.y){
					windLeft = false;
				}
				if (PlayerPos.position.y >= windTurnPoints[2].position.y && PlayerPos.position.y <= windTurnPoints[3].position.y){
					windLeft = true;
				}
				if (PlayerPos.position.y >= windTurnPoints[3].position.y && PlayerPos.position.y <= windTurnPoints[4].position.y){
					windLeft = false;
			}
			// Debug.Log(windLeft);
			}
			StartCoroutine(SpawnWind());
		}
	}

      void spawnWindCurve(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPointsL[SPnum];
            var windTemp = Instantiate(windCurve, spawnPoint.position, Quaternion.identity);
			windTemp.transform.parent = gameObject.transform;
      }
	  
      void spawnWindCircle(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPointsL[SPnum];
            var windTemp = Instantiate(windCircle, spawnPoint.position, Quaternion.identity);
			windTemp.transform.parent = gameObject.transform;
      }
	  
      void spawnWindCurveR(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPointsR[SPnum];
            var windTemp = Instantiate(windCurve, spawnPoint.position, Quaternion.Euler(new Vector3(0, 180, 0)));
			windTemp.transform.parent = gameObject.transform;
      }
	  
      void spawnWindCircleR(){
            int SPnum = Random.Range(0, rangeEnd);
            spawnPoint = spawnPointsR[SPnum];
            var windTemp = Instantiate(windCircle, spawnPoint.position, Quaternion.Euler(new Vector3(0, 180, 0)));
			windTemp.transform.parent = gameObject.transform;
      }
	  
	  void spawnLeft(){
			spawnWindCurve();
			spawnWindCircle();
			spawnWindCurve();
	  }
	  void spawnRight(){
			spawnWindCurveR();
			spawnWindCircleR();
			spawnWindCurveR();
	  }
	  
	IEnumerator SpawnWind(){

		if (singleDirection || multiDirection) {
				if (windLeft == false) {
				spawnRight();
				yield return new WaitForSeconds(1f);
				spawnRight();
				yield return new WaitForSeconds(0.5f);
				spawnRight();
				yield return new WaitForSeconds(8.5f);
			}
			if (windLeft == true) {
				spawnLeft();
				yield return new WaitForSeconds(1f);
				spawnLeft();
				yield return new WaitForSeconds(0.5f);
				spawnLeft();
				yield return new WaitForSeconds(8.5f);
			}
		}
	}
}
