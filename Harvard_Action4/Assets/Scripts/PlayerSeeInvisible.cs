using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSeeInvisible : MonoBehaviour
{
	private SpriteRenderer spRen;
	private BoxCollider2D BoxCo2d;
	
    void Start()
    {
        spRen = GetComponent<SpriteRenderer>();
		BoxCo2d = GetComponent<BoxCollider2D>();
		spRen.enabled = false;
		BoxCo2d.enabled = false;
    }

    // sub to event
    void OnEnable()
    {
        EventManager.On15seed += ShowObject;
    }

    // unsub to event
    void OnDisable()
    {
        EventManager.On15seed -= ShowObject;
    }
	
    // opens door to correct position when button is pressed (event)
    void ShowObject()
    {
        if (tag == this.tag)
        {
			spRen.enabled = true;
			BoxCo2d.enabled = true;
        }
    }
}
