using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	private int score;
	private int stars;

	public Text scoreText;
	public Text starsText;
	public Text gameOverText;

	private bool dead;
	private bool bonusRound;

	void Start () {
		score = 0;
		stars = 0;
		gameOverText.text = "";
		UpdateScore();
		UpdateStars();
		dead = false;
		if (Random.Range(0, 100) > 98) {
			bonusRound = true;
		} else {
			bonusRound = false;
		}
		if (bonusRound) {
			GameObject.Find("BonusRound").SetActive(true);
		} else {
			GameObject.Find("BonusRound").SetActive(false);
		}
		StartCoroutine(IncreasingScore());
	}

	void Update() {
		if (dead) {
			foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")) {
				Destroy(obj);
			}
			Destroy(GameObject.FindGameObjectWithTag("Player"));

			gameOverText.color = Random.ColorHSV();
			gameOverText.text = "Game Over";

			if (PlayerPrefs.GetInt("highScore") < score) {
				PlayerPrefs.SetInt("highScore", score);
			}
			stars += PlayerPrefs.GetInt("stars");
			PlayerPrefs.SetInt("stars", stars);

			StartCoroutine(ReloadScene());
			dead = false;
		}
		if (Input.GetKeyDown("space")) {
			score += 100;
			UpdateScore();
		}
	}

	IEnumerator ReloadScene() {
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(0);
	}

	IEnumerator IncreasingScore() {
		while (true) {
			if (bonusRound) {
				AddScore(2);
			} else {
				AddScore(1);
			}
			yield return new WaitForSeconds(1);
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
			stars++;
		}
		UpdateStars();
	}

	void UpdateScore() {
		scoreText.text = score.ToString();
	}

	void UpdateStars() {
		starsText.text = stars.ToString();
        UpdateScore();
	}

	public void SetDead(bool bil) {
		dead = bil;
	}

	public int GetScore() {
		return score;
	}

}
