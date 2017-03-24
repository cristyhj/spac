using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    public ParticleSystem particles;
    private Data data;
    public AudioClip[] clips;
    private new AudioSource audio;

    private Vector2 pos;

    void Start() {
        pos.x = Camera.main.pixelWidth;
        pos.y = Camera.main.pixelHeight;
        pos = Camera.main.ScreenToWorldPoint(pos);
        
        data = GameObject.Find("Data").GetComponent<Data>();
        audio = GetComponent<AudioSource>();
    }

    void Update() {
        if (transform.position.x > pos.x) {
            transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -pos.x) {
            transform.position = new Vector3(-pos.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > pos.y) {
            transform.position = new Vector3(transform.position.x, pos.y, transform.position.z);
        }
        if (transform.position.y < -pos.y) {
            transform.position = new Vector3(transform.position.x, -pos.y, transform.position.z);
        }
    }

    

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy1" || coll.gameObject.tag == "Enemy2" || coll.gameObject.tag == "Bullet2" || coll.gameObject.tag == "Enemy3") {
            nGameController gc = GameObject.Find("GameController").GetComponent<nGameController>();
            Instantiate(particles, transform.position, Quaternion.identity);
            if (data.sound == 1) {
                audio.clip = clips[2];
                audio.Play();
            }
            gc.GameOver();
        }
		if (coll.gameObject.tag == "Bonus1") {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy1")) {
                Instantiate(particles, obj.transform.position, Quaternion.identity);
                Destroy(obj);
                Destroy(coll.gameObject);
                if (data.sound == 1) {
                    audio.clip = clips[0];
                    audio.Play();
                }
            }
		}
		if (coll.gameObject.tag == "Bonus2") {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy2")) {
                Instantiate(particles, obj.transform.position, Quaternion.identity);
                Destroy(obj);
                Destroy(coll.gameObject);
                if (data.sound == 1) {
                    audio.clip = clips[0];
                    audio.Play();
                }

            }
        }
        if (coll.gameObject.tag == "Bonus3") {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy3")) {
                Instantiate(particles, obj.transform.position, Quaternion.identity);
                Destroy(obj);
                Destroy(coll.gameObject);
                if (data.sound == 1) {
                    audio.clip = clips[0];
                    audio.Play();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Star") {
            nGameController gc = GameObject.Find("GameController").GetComponent<nGameController>();
            gc.AddStar();
            gc.AddScore(5);
            coll.gameObject.GetComponent<ParticleSystem>().Play();
            coll.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            StartCoroutine(AutoDestroy(coll.gameObject));
            if (data.sound == 1) {
                audio.clip = clips[1];
                audio.Play();
            }
        }
    }

    IEnumerator AutoDestroy(GameObject g) {
        yield return new WaitForSeconds(3f);
        Destroy(g);
    }

}
