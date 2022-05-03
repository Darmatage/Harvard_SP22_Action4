using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomAbility : MonoBehaviour
{
	//Depencencies 
	private Camera cameraComp;
    private GameHandler gameHandler;
	public int zoomMod = 10;
	public int defaultZoom = 2;
	private bool zooming = false;
	
    void Start()
    {
        cameraComp = GetComponent<Camera>();
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		cameraComp.orthographicSize = defaultZoom;
    }

    void Update()
    {
        if(Input.GetButtonDown("Zoom") && zooming == false){
			zooming = true;
		} else if(Input.GetButtonDown("Zoom") && zooming == true){
			zooming = false;
		}
		
		if(GameHandler.zoomOut == true && zooming == true) {
			cameraComp.orthographicSize += 50 * Time.deltaTime;
			if(cameraComp.orthographicSize > zoomMod) {
				cameraComp.orthographicSize = zoomMod;
			}
		} else {
			cameraComp.orthographicSize -= 30 * Time.deltaTime;
			if(cameraComp.orthographicSize < defaultZoom) {
				cameraComp.orthographicSize = defaultZoom;
			}
		}
    }
}
