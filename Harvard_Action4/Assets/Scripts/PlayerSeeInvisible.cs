using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeeInvisible : MonoBehaviour
{
	private SpriteRenderer spRen;
	private BoxCollider2D BoxCo2d;
    // Start is called before the first frame update
    void Start()
    {
        spRen = gameObject.GetComponent<SpriteRenderer>();
		BoxCo2d = gameObject.GetComponent<BoxCollider2D>();
		spRen.SetActive(false);
		BoxCo2d.SetActive(false);
    }

    // sub to event
    void OnEnable()
    {
        EventManager.on15seed += ShowObject;
    }

    // unsub to event
    void OnDisable()
    {
        EventManager.on15seed -= ShowObject;
    }
	
    // opens door to correct position when button is pressed (event)
    void ShowObject(string tag)
    {
        // checks that button tag is the gate tag
        if (startPos.y - 5f < transform.position.y && tag == this.tag)
        {
            spRen.SetActive(true);
			BoxCo2d.SetActive(true);
        }
        
    }
}
