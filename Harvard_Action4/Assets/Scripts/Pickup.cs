using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
	  private GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      public bool isSeedPickUp = false;
	  public int SeedId;
	  public bool isEssencePickUp = true;
      public double seedIncrease = 1;
	  public double essenceIncrease = 1000;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
			
			//check is play already has this seed
			if ((isSeedPickUp == true) && (GameHandler.seeds[SeedId] == 1)){
                StartCoroutine(DestroyThis());
			}
      }
	
      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  GetComponent<Collider2D>().enabled = false;
                  GetComponent<AudioSource>().Play();
                  StartCoroutine(DestroyThis());
				  
				  if (isSeedPickUp == true) {
					  gameHandler.playerGetSeed(SeedId);
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
            Destroy(gameObject);
      }
}