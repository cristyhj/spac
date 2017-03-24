using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {

    public static Data control;

    public int sound;
    public int highScore;
    public int stars;
    public int paused = 0;
    public bool loggedInGPG = false;
    public bool gameOver = false;
    public int scoreToPost = 0;

    void LoadAll() {
        sound = PlayerPrefs.GetInt("sound", 1);
        highScore = PlayerPrefs.GetInt("highScore", 1);
        stars = PlayerPrefs.GetInt("stars", 1);
        paused = 0;
    }

    void Awake() {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
            LoadAll();
        } else if (control != this) {
            Destroy(gameObject);
        }
    }

    void Update() {
        AudioSource audio = GetComponent<AudioSource>();
        if (sound == 1) {
            audio.volume = 1f;
        } else {
            audio.volume = 0f;
        }
    }
}
