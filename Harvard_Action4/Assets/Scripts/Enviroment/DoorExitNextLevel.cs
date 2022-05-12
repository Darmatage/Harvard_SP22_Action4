using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExitNextLevel : MonoBehaviour
{
    public string NextLevel = "MainMenu";

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
			
		FindObjectOfType<AudioManager>().Play(NextLevel);
            SceneManager.LoadScene(NextLevel);
        }
    }
}
