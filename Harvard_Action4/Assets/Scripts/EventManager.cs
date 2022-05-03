using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
	//dependencies 
    private GameHandler gameHandler;
	
	//Testing
	public bool Testing = false;
	public bool TEST_DoubleJump = true;
	public bool TEST_SeeInvisible = true;
	public bool TEST_crouchStopWind = false;
	public bool TEST_zoomOut = false;
	
	//event to show invisiable walls 
	public delegate void invWallCheck();
    public static event invWallCheck CanSeeInv;
	
	void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
	
    void Update()
    {
		if (Testing == true) {
			if (TEST_DoubleJump == true) {
				GameHandler.doubleJumpActive = true;
			}
			
			if (TEST_SeeInvisible == true) {
				GameHandler.seeInvisibleActive = true;
			}
			
			if (TEST_crouchStopWind == true) {
				GameHandler.crouchStopWind = true;
			}
			
			if (TEST_zoomOut == true) {
				GameHandler.zoomOut = true;
			}
		}
		
        if (GameHandler.seeInvisibleActive == true) {
			if  (CanSeeInv != null) {
				CanSeeInv();
			}
		}
    }
}
