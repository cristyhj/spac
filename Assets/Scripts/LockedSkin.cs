using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockedSkin : MonoBehaviour {

    public Sprite skin;

	void Start () {
        if (PlayerPrefs.GetInt(gameObject.name, 0) == 1) {
            ChangeImage();
            GetComponentInChildren<Text>().text = "Owned!";
        }
	}

    public void ChangeImage() {
        gameObject.GetComponent<Image>().sprite = skin;
    }

    public Sprite GetImage() {
        return gameObject.GetComponent<Image>().sprite;
    }

}
