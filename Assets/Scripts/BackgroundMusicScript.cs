using UnityEngine;
using System.Collections;

public class BackgroundMusicScript : MonoBehaviour {

	public static BackgroundMusicScript control;
	private AudioSource audioS;
	private SoundEffetsScript soundEffect;
	private bool sound;
	public AudioClip[] bgm;

	void Awake() {
		if (control == null) {
			DontDestroyOnLoad(gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		audioS = GetComponent<AudioSource>();
		soundEffect = FindObjectOfType<SoundEffetsScript>();
		if (soundEffect == null) {
			Debug.Log("Nu am gasit scriptul SiundEffect obiect");
		}
		sound = soundEffect.GetSoundInformation();
		audioS.clip = bgm[Random.Range(0, 4)];
	}
	
	void Update () {
		sound = soundEffect.GetSoundInformation();
		if (sound) {
			audioS.mute = false;
		} else {
			audioS.mute = true;
		}
		if (!audioS.isPlaying) {
			audioS.clip = bgm[Random.Range(0, 4)];
			audioS.Play();
		}
	}
}
