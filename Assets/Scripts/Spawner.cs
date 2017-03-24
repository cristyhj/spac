using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float minTime;
	public float maxTime;

	public float starTime;

	public GameObject particle;
	public GameObject enemy;
	public GameObject star;
	public GameObject enemy2;
	public GameObject bonus;
	public GameObject bonus1;
    public GameObject enemy3;
	private Vector3 position;
	private GameController gameController;

	void Start() {
		gameController = GetComponent<GameController>();
		position.z = particle.transform.position.z;
		StartCoroutine(SpawnEnemy());
		StartCoroutine(SpawnEnemy2());
		StartCoroutine(SpawnStar());
		StartCoroutine(SpawnBonus());
		StartCoroutine(SpawnBonus1());
        StartCoroutine(SpawnEnemy3());
	}

	IEnumerator SpawnEnemy() {
		while (particle != null) {
			position.x = Random.Range(-13f, 13f);
			position.y = Random.Range(-8f, 8f);
			Instantiate(enemy, position, Quaternion.identity);
			yield return new WaitForSeconds(Random.Range(minTime, maxTime));
		}
	}
	IEnumerator SpawnStar() {
		while (particle != null) {
			yield return new WaitForSeconds(Random.Range(2f, starTime));
			position.x = Random.Range(-13f, 13f);
			position.y = Random.Range(-8f, 8f);
			Instantiate(star, position, Quaternion.identity);
		}
	}

	IEnumerator SpawnEnemy2() {
		while (particle != null) {
			if (gameController.GetScore() > 100) {
				position.x = Random.Range(-13f, 13f);
				position.y = Random.Range(-8f, 8f);
				Instantiate(enemy2, position, Quaternion.identity);
				yield return new WaitForSeconds(10f);
			}
			yield return new WaitForSeconds(1f);
		}
	}

	IEnumerator SpawnBonus() {
		while (particle != null) {
			yield return new WaitForSeconds(Random.Range(2f, 10f));
			position.x = Random.Range(-13f, 13f);
			position.y = Random.Range(-8f, 8f);
			Instantiate(bonus, position, Quaternion.identity);
		}
	}

	IEnumerator SpawnBonus1() {
		while (particle != null) {
			yield return new WaitForSeconds(Random.Range(10f, 20f));
			position.x = Random.Range(-13f, 13f);
			position.y = Random.Range(-8f, 8f);
			Instantiate(bonus1, position, Quaternion.identity);
		}
	}

    IEnumerator SpawnEnemy3() {
        while (particle != null) {
            if (gameController.GetScore() > 30) {
                position.x = Random.Range(-13f, 13f);
                position.y = Random.Range(-8f, 8f);
                Instantiate(enemy3, position, Quaternion.identity);
                yield return new WaitForSeconds(3f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
