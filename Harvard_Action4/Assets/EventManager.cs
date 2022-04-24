using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private GameHandler gameHandler;
	public delegate void on15seed(string tag);
    public static event on15seed at15seed;
	
	void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }
	
    // Start is called before the first frame update
    void update()
    {
        if (gamehandler.heldSeed >= 15) {
			at15Seed();
		}
    }
}
