using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubTree : MonoBehaviour
{
    private GameHandler gameHandler;
	public GameObject tree0;
	public GameObject tree1;
	public GameObject tree2;
	public GameObject tree3;
	public GameObject tree4;
	public GameObject tree5;
    // Start is called before the first frame update
    void Start()
    {
		gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
		tree0.SetActive(false);
		tree1.SetActive(false);
		tree2.SetActive(false);
		tree3.SetActive(false);
		tree4.SetActive(false);
		tree5.SetActive(false);
    }    
	
	void Update()
    {
        if (GameHandler.tree0 == true) {
			tree0.SetActive(true);
		}
        if (GameHandler.tree1 == true) {
			tree0.SetActive(false);
			tree1.SetActive(true);
		}
        if (GameHandler.tree2 == true) {
			tree1.SetActive(false);
			tree2.SetActive(true);
		}
        if (GameHandler.tree3 == true) {
			tree2.SetActive(false);
			tree3.SetActive(true);
		}
        if (GameHandler.tree4 == true) {
			tree3.SetActive(false);
			tree4.SetActive(true);
		}
        if (GameHandler.tree5 == true) {
			tree4.SetActive(false);
			tree5.SetActive(true);
		}
    }
	
	void OnTriggerEnter2D(Collider2D other)
    {	
		if (other.gameObject.tag == "Player") {
			GameHandler.onTree = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			GameHandler.onTree = false;
		}
	}
}
