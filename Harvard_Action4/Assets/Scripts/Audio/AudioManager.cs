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
		Sound ns = Array.Find(sounds, sound => sound.name == name);
		if (ns.source == null){
			return;
		}
		ns.source.Play();
	}
	
	public void StopAll() {
		foreach (Sound s in sounds) {
			if (s.source == null){
				Debug.Log(s.name + " is null");
			} else if (s.source.isPlaying) {
				Debug.Log(s.name + " stopped");
				s.source.Stop();
			}
		}
	}
	
	public void Stop(string name) {
		Sound os = Array.Find(sounds, sound => sound.name == name);
		if (os.source == null){
			return;
		}
		os.source.Stop();
	}
	
	public void PlaySFX(string name) {
		
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s.source == null){
			return;
		}
		s.source.Play();
	}
}
