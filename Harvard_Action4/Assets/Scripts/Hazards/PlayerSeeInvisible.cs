using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 
using UnityEngine.Tilemaps;

public class PlayerSeeInvisible : MonoBehaviour
{
	private TilemapRenderer tR;
	private TilemapCollider2D tC2d;
	
    void Start()
    {
        tR = GetComponent<TilemapRenderer>();
		tC2d = GetComponent<TilemapCollider2D>();
		tR.enabled = false;
		tC2d.enabled = false;
    }

    // sub to event
    void OnEnable()
    {
        EventManager.CanSeeInv += ShowObject;
    }

    // unsub to event
    void OnDisable()
    {
        EventManager.CanSeeInv -= ShowObject;
    }
	
    // opens door to correct position when button is pressed (event)
    void ShowObject()
    {
        if (tag == this.tag)
        {
			tR.enabled = true;
			tC2d.enabled = true;
        }
    }
}
