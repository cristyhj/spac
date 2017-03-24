using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour {

	public Sprite soundON;
	public Sprite soundOFF;
    private Text starsText;
	private GameObject soundButton;
	private SoundEffetsScript soundControl;
    public Text starsTextGlobal;
    public GameObject selectedSkin;
	
	void Awake() {
        selectedSkin.GetComponent<Image>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("currentSkin")) as Sprite;
        soundButton = GameObject.Find("SoundOptionsButton");
		soundControl = FindObjectOfType<SoundEffetsScript>();
		if (soundButton == null){
			Debug.Log("Couldn't find SoundOptionsButton GameObject.");
		}
		if (soundControl.sound) {
			soundButton.GetComponent<Image>().sprite = soundON;
		} else {
			soundButton.GetComponent<Image>().sprite = soundOFF;
		}
	}

	public void LoadScene(int scene) {
		SceneManager.LoadScene(scene);
	}

	public void SoundOnOff() {
		if (soundControl.sound) {
			soundButton.GetComponent<Image>().sprite = soundOFF;
			soundControl.sound = false;
		} else {
			soundButton.GetComponent<Image>().sprite = soundON;
			soundControl.sound = true;
		}
	}

	public void ExitGame() {
		PlayerPrefs.SetInt("sound", soundControl.sound ? 1 : 0);
		Application.Quit();
	}

    public void UnlockSkin(GameObject obj) {
        if (PlayerPrefs.GetInt(obj.name, 0) == 0) {
            int money = PlayerPrefs.GetInt("stars");
            int cost = int.Parse(obj.GetComponentInChildren<Text>().text);
            if (money > cost) {
                PlayerPrefs.SetInt("stars", money - cost);
                PlayerPrefs.SetInt(obj.name, 1);
                starsTextGlobal.text = "Stars: " + (money - cost);
                obj.GetComponent<LockedSkin>().ChangeImage();
                obj.GetComponentInChildren<Text>().text = "Unlocked!";
            } else {
                StartCoroutine(WaitDegeaba(obj, cost));
            }
        } else {
            PlayerPrefs.SetString("currentSkin", obj.name);
            selectedSkin.GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
        }
    }

    IEnumerator WaitDegeaba(GameObject obj, int cost) {
        obj.GetComponentInChildren<Text>().text = "Not enought!";
        yield return new WaitForSeconds(1.5f);
        obj.GetComponentInChildren<Text>().text = cost.ToString();
    }

    public void ResetPlayerPrefs() {
       // PlayerPrefs.SetInt("stars", 0);
        PlayerPrefs.SetInt("highScore", 0);
        for (int i = 1; i <= 3; i++) {
            PlayerPrefs.SetInt("skin" + i, 0);
        }
    }
}
