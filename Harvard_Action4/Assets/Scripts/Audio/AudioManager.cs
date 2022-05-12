using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
	public Sound[] sounds;
	public AudioMixerGroup mixer;
	
	public static AudioManager instance;
	
	void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			Destroy(gameObject);
			return;
		}
		
		DontDestroyOnLoad(gameObject);
		
		foreach(Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			
			s.source.volume = s.volume;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = mixer;
		}
	}
	
	public void Play(string name) {
		StopBgm();
		
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s == null){
			Debug.Log(s + "not found");
			return;
		}
		s.source.Play();
	}
	
	public void StopBgm() {
		foreach (Sound s in sounds) {
			if (s == null){
				Debug.Log(s + "not found");
			} else {
				s.source.Stop();
			}
		}
	}
	
}
