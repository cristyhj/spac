using UnityEngine;
using System.Collections;

public class nSpawner : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject bonus1;
    public GameObject bonus2;
    public GameObject bonus3;
    public GameObject star;

    public Vector2 pos;
    private Vector2 player;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        pos.x = Camera.main.pixelWidth;
        pos.y = Camera.main.pixelHeight;
        pos = Camera.main.ScreenToWorldPoint(pos);

        StartCoroutine(SpawnEnemy1());
        StartCoroutine(SpawnEnemy2());
        StartCoroutine(SpawnEnemy3());
        StartCoroutine(SpawnStar());
        StartCoroutine(SpawnBonus1());
        StartCoroutine(SpawnBonus2());
    }

    Vector2 RandomWorldPoint() {
        return new Vector2(Random.Range(-pos.x, pos.x), Random.Range(-pos.y, pos.y));
    }

    Vector2 RandomWorldNoPlayerPoint(float distance) {
        Vector2 ret = new Vector2(Random.Range(-pos.x, pos.x), Random.Range(-pos.y, pos.y));
        while (Mathf.Pow(ret.x - player.x, 2) + Mathf.Pow(ret.y - player.y, 2) < Mathf.Pow(distance, 2)) {
            ret = new Vector2(Random.Range(-pos.x, pos.x), Random.Range(-pos.y, pos.y));
        }
        return ret;
    }

    Vector2 RandomOutsideWorld() {
        Vector2 ret;
        ret.x = Random.Range(pos.x, pos.x + 1f);
        ret.y = Random.Range(pos.y, pos.y + 1f);
        if (Random.value > 0.5f) {
            ret.x = Random.Range(pos.x - 1f, pos.x + 1f);
        } else {
            ret.y = Random.Range(pos.y - 1f, pos.y + 1f);
        }
        if (Random.value > 0.5f) {
            ret.x *= -1;
        }
        if (Random.value > 0.5f) {
            ret.y *= -1;
        }
        return ret;
    }

    IEnumerator SpawnEnemy1() {
        while (true) {
            yield return new WaitForSeconds(3f);
            Instantiate(enemy1, RandomOutsideWorld(), Quaternion.identity);
        }
    }

    IEnumerator SpawnEnemy2() {
        yield return new WaitForSeconds(20f);
        while (true) {
            yield return new WaitForSeconds(5f);
            Instantiate(enemy2, RandomOutsideWorld(), Quaternion.identity);
        }
    }

    IEnumerator SpawnEnemy3() {
        yield return new WaitForSeconds(50f);
        while (true) {
            yield return new WaitForSeconds(10f);
            if (GameObject.FindGameObjectsWithTag("Enemy3").Length == 0) {
                Instantiate(enemy3, RandomOutsideWorld(), Quaternion.identity);
            }
        }
    }

    IEnumerator SpawnStar() {
        while (true) {
            yield return new WaitForSeconds(5f);
            Instantiate(star, RandomWorldPoint(), Quaternion.identity);
        }
    }

    IEnumerator SpawnBonus1() {
        while (true) {
            yield return new WaitForSeconds(Random.value * 30f + 10f);
            Instantiate(bonus1, RandomWorldPoint(), Quaternion.identity);
        }
    }

    IEnumerator SpawnBonus2() {
        yield return new WaitForSeconds(20f);
        while (true) {
            yield return new WaitForSeconds(Random.value * 50f + 20f);
            Instantiate(bonus2, RandomWorldPoint(), Quaternion.identity);
        }
    }

    IEnumerator SpawnBonus3() {
        yield return new WaitForSeconds(50f);
        while (true) {
            yield return new WaitForSeconds(Random.value * 20f + 30f);
            Instantiate(bonus3, RandomWorldPoint(), Quaternion.identity);
        }
    }
}