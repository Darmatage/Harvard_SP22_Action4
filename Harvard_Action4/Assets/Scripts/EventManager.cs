using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    private GameHandler gameHandler;
	
	//event to show invisiable walls 
	public delegate void have15seed();
    public static event have15seed On15seed;
	
	void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
	
    void Update()
    {
        if (GameHandler.heldSeed >= 1) {
			if  (On15seed != null) {
				On15seed();
			}
		}
    }
}
