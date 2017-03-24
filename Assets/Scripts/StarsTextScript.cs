using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsTextScript : MonoBehaviour {

    private Text scoretext;

	void Start () {
        scoretext = GetComponent<Text>();
        scoretext.text = "Stars: " + PlayerPrefs.GetInt("stars", 0);
	}
}
