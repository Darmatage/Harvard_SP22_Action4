using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
	//dependencies 
    private GameHandler gameHandler;
	
	//Temp interactions 
	public double essenceForDoubleJump = 5000;
	public double seedForSeeInvisible = 15;
	
	//event to show invisiable walls 
	public delegate void invWallCheck();
    public static event invWallCheck CanSeeInv;
	
	void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
	
    void Update()
    {
		if (GameHandler.heldEssence >= essenceForDoubleJump) {
			GameHandler.doubleJumpActive = true;
		}
		
		if (GameHandler.heldSeed >= seedForSeeInvisible) {
			GameHandler.seeInvisibleActive = true;
		}
		
        if (GameHandler.seeInvisibleActive == true) {
			if  (CanSeeInv != null) {
				CanSeeInv();
			}
		}
    }
}
