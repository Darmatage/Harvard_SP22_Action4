using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventManager : MonoBehaviour
{
    private GameHandler gameHandler;
	public delegate void on15seed();
    public static event on15seed at15seed;
	
	void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
	
    // Start is called before the first frame update
    void update()
    {
        if (GameHandler.heldSeed >= 15) {
			if  (at15seed != null) {
				//at15Seed;
			}
		}
    }
}
