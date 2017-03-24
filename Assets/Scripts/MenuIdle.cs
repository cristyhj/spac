using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuIdle : MonoBehaviour {

	public ParticleSystem particle;
	public float density;

	public Text highScoreText;
	public Text starsText;

	void Start () {
		StartCoroutine(SpawnParticles());
		int highScore = PlayerPrefs.GetInt("highScore");
		int stars = PlayerPrefs.GetInt("stars");
		highScoreText.text = "High Score: " + highScore;
		starsText.text = "Stars: " + stars;
	}
	
	IEnumerator SpawnParticles() {
		while (true) {
			particle.startColor = Random.ColorHSV();
			Instantiate(particle, new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 1f), Quaternion.identity);
			yield return new WaitForSeconds(density);
		}
	}
}
