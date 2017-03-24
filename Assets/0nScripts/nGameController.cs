using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class nGameController : MonoBehaviour {

    private Data data;

    private int score = 0;
    private int stars = 0;
    public Text scoreText;

    public GameObject goMenu;
    
    private bool bonusRound = false;

    void Start() {
        data = GameObject.Find("Data").GetComponent<Data>();
        if (data == null) {
            Debug.Log("Nu am gasit Data component");
        }
        if (Random.value > .925) {
            bonusRound = true;
            GameObject.Find("Background").transform.position = new Vector3(0f, 0f, 300f);
        }
        data.gameOver = false;
        StartCoroutine(Score());
        int fir = PlayerPrefs.GetInt("firstPlay", 1);
        if (fir == 1) {
            ActivateGooServices.UnlockAchievement(GPGSIDs.achievement_first_play);
            PlayerPrefs.SetInt("firstPlay", 0);
        }
    }
    

    void UpdateScore() {
        scoreText.text = score.ToString();
    }
    
    IEnumerator Score() {
        UpdateScore();
        while (true) {
            yield return new WaitForSeconds(1f);
            if (bonusRound) {
                score += 2;
            } else {
                score += 1;
            }
            UpdateScore();
        }
    }

    public void AddScore(int scoreValue) {
        score += scoreValue;
        UpdateScore();
    }

    public void AddStar() {
        if (bonusRound) {
            stars += 2;
        } else {
            stars += 1;
        }
    }

    public void GameOver() {
        goMenu.SetActive(true);
        data.gameOver = true;
        data.scoreToPost = score;
        if (score == 27) {
            ActivateGooServices.UnlockAchievement(GPGSIDs.achievement_27_points);
        }
        ActivateGooServices.IncrementAchievement(GPGSIDs.achievement_points, 1);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy1")) {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy2")) {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy3")) {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player")) {
            obj.GetComponent<SpriteRenderer>().sprite = null;
            obj.GetComponent<TrailRenderer>().enabled = false;
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Star")) {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bonus1")) {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bonus2")) {
            Destroy(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Bonus3")) {
            Destroy(obj);
        }

        int highScore = PlayerPrefs.GetInt("highScore");
        GameObject tx = GameObject.Find("HighScore");
        GameObject htx = GameObject.Find("HighHighScore");
        int st = PlayerPrefs.GetInt("stars");
        PlayerPrefs.SetInt("stars", st + stars);
        htx.GetComponent<Text>().text = "Highscore: " + highScore;
        if (score > highScore) {
            tx.GetComponent<Text>().text = "New Highscore: " + score;
            PlayerPrefs.SetInt("highScore", score);
        } else {
            tx.GetComponent<Text>().text = "Score: " + score;
        }
        if (Random.value > .80) {
            StartCoroutine(_ShowAds());
        }
        gameObject.SetActive(false);
    }

    IEnumerator _ShowAds() {
        while (!Advertisement.IsReady()) {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Show();
    }
}
