using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		FindObjectOfType<AudioManager>().StopAll();
		FindObjectOfType<AudioManager>().Play("MainTheme");
    }
}
