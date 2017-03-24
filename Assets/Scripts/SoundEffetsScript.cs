using UnityEngine;
using System.Collections;

public class SoundEffetsScript : MonoBehaviour {

	public static SoundEffetsScript control;
	private AudioSource audioS;
	public bool sound;
	public AudioClip[] clip;

	void Awake() {
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		}
	}
	
	void Start () {
		audioS = GetComponent <AudioSource>();
	}

	public void Play(int IDclip) {
		if (sound) {
			audioS.clip = clip[IDclip];
			audioS.Play();
		}
	}

	public bool GetSoundInformation() {
		return sound;
	}
}