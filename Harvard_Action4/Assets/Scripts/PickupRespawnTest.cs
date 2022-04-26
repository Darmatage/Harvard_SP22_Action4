using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRespawnTest : MonoBehaviour
{
	  private GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool isSeedPickUp = false;
	  public bool isEssencePickUp = true;
      public double seedIncrease = 1;
	  public double essenceIncrease = 1000;
		private SpriteRenderer spRen;
		private BoxCollider2D BoxCo2d;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());

				  if (isSeedPickUp == true) {
					  //gameHandler.playerGetSeed(seedIncrease);
					  //playerPowerupVFX.powerup();
				  }

				  if (isEssencePickUp == true) {
					  gameHandler.playerGetEssence(essenceIncrease);
					  //playerPowerupVFX.powerup();
				  }
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.1f);
						spRen = GetComponent<SpriteRenderer>();
				BoxCo2d = GetComponent<BoxCollider2D>();
				spRen.enabled = false;
				BoxCo2d.enabled = false;
      }

}
