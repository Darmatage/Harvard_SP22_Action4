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
        //EventManager.on15seed += ShowObject;
    }

    // unsub to event
    void OnDisable()
    {
        //EventManager.on15seed -= ShowObject;
    }
	
    // opens door to correct position when button is pressed (event)
    void ShowObject(string tag)
    {
        if (tag == this.tag)
        {
			spRen.enabled = true;
			BoxCo2d.enabled = true;
        }
    }
}
