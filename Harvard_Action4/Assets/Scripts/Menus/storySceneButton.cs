using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class storySceneButton : MonoBehaviour
{
	public GameObject art1;
	public GameObject art2;
	public GameObject art3;
	public GameObject GUI;
	public int count = 0;
    // Start is called before the first frame update
    void Awake()
    {
        art1.SetActive(true);
        art2.SetActive(false);
        art3.SetActive(false);
		GUI.SetActive(false);
    }

	public void button_Next(){
		if (count == 0) {
			art1.SetActive(false);
			art2.SetActive(true);
			count = 1;
		} else if (count == 1) {
			art2.SetActive(false);
			art3.SetActive(true);
			count = 2;
		} else if (count == 2) {
			GUI.SetActive(true);
			FindObjectOfType<AudioManager>().Play("Level0");
			FindObjectOfType<AudioManager>().Stop("MainTheme");
			SceneManager.LoadScene("Level0");
		}
	}
}
