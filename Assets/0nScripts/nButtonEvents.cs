using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Advertisements;

public class nButtonEvents : MonoBehaviour {

    private Data data;
    public string zoneId;

    public Text starsTextGlobal;
    public GameObject selectedSkin;
    public Text awardText;

    void Awake() {
        if (SceneManager.GetActiveScene().buildIndex == 3) {
            selectedSkin.GetComponent<Image>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("currentSkin", "basic")) as Sprite;
            starsTextGlobal.text = PlayerPrefs.GetInt("stars").ToString();
        }
    }

    void Start() {
        data = GameObject.Find("Data").GetComponent<Data>();
        if (data == null) {
            Debug.Log("Nu a gasit data");
        }
    }

    public void LoadScene(int scene) {
        SceneManager.LoadScene(scene);
    }

    public void ChangeSound() {
        if (data.sound == 1) {
            data.sound = 0;
            PlayerPrefs.SetInt("sound", 0);
        } else {
            data.sound = 1;
            PlayerPrefs.SetInt("sound", 1);
        }
    }

    public void Pause() {
        if (data.gameOver) return;
        if (data.paused == 0) {
            data.paused = 1;
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
            data.paused = 0;
        }
    }

    public void UnlockSkin(GameObject obj) {
        if (PlayerPrefs.GetInt(obj.name, 0) == 0) {
            int money = PlayerPrefs.GetInt("stars");
            int cost = int.Parse(obj.GetComponentInChildren<Text>().text);
            if (money > cost) {
                PlayerPrefs.SetInt("stars", money - cost);
                PlayerPrefs.SetInt(obj.name, 1);
                starsTextGlobal.text = (money - cost).ToString();
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
        obj.GetComponentInChildren<Text>().text = "No!";
        yield return new WaitForSeconds(1.5f);
        obj.GetComponentInChildren<Text>().text = cost.ToString();
    }

    public void OpenURL(string url) {
        Debug.Log(Application.persistentDataPath);
        Application.OpenURL(url);
    }

    public void ShowAds() {
        StartCoroutine(_ShowAds());
    }

    IEnumerator _ShowAds() {
        while (!Advertisement.IsReady()) {
            yield return new WaitForSeconds(0.5f);
        }

        if (string.IsNullOrEmpty(zoneId)) zoneId = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show(zoneId, options);
    }

    private void HandleShowResult(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                string date = PlayerPrefs.GetString("date");
                if (!string.IsNullOrEmpty(date)) {
                    System.DateTime then = System.DateTime.Parse(date);
                    System.DateTime now = System.DateTime.Now;
                    System.TimeSpan diff = now - then;
                    double x = diff.TotalDays;
                    if (x > 1f) {
                        int starsN = PlayerPrefs.GetInt("stars") + 100;
                        starsTextGlobal.text = starsN.ToString();
                        PlayerPrefs.SetInt("stars", starsN);
                        PlayerPrefs.SetString("date", now.ToString());
                        ActivateGooServices.UnlockAchievement(GPGSIDs.achievement_thank_you);
                    } else {
                        awardText.text = "Come back tomorrow!";
                        break;
                    }
                } else {
                    int starsN = PlayerPrefs.GetInt("stars") + 100;
                    starsTextGlobal.text = starsN.ToString();
                    PlayerPrefs.SetInt("stars", starsN);
                    PlayerPrefs.SetString("date", System.DateTime.Now.ToString());
                }
                awardText.text = "Thank you! Here is 100 stars!";
                break;
            case ShowResult.Skipped:
                awardText.text = "Video skipped! No award, sorry!";
                break;
            case ShowResult.Failed:
                break;
        }
    }

    public void BlingBling() {
        ActivateGooServices.UnlockAchievement(GPGSIDs.achievement_bling_bling);
    }

}