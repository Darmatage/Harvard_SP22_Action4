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
			s.source.playOnAwake = false;
			s.source.outputAudioMixerGroup = mixer;
		}
	}
	
	public void Play(string name) {
		foreach (Sound s in sounds) {
			if (s.source == null){
				Debug.Log(s.name + " not found");
			} else if (s.source.isPlaying) {
				s.source.Stop();
			}
		}
		
		Sound ns = Array.Find(sounds, sound => sound.name == name);
		if (ns.source == null){
			Debug.Log(ns.name + " not found");
			return;
		}
		Debug.Log(ns.name + " Playing");
		ns.source.Play();
	}
}
