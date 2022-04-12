using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	  private GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool isMoneyPickUp = true;
      public bool isSpeedBoostPickUp = false;

      public int moneyIncrease = 1000;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());
				  
				  if (isMoneyPickUp == true) {
                        gameHandler.playerGetMoney(moneyIncrease);
                        //playerPowerupVFX.powerup();
                  }
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.1f);
            Destroy(gameObject);
      }

}