using UnityEngine;
using System.Collections;

public class RandomShooting : MonoBehaviour {

    public float waitTime;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
        StartCoroutine(Shoot());
	}
	
	IEnumerator Shoot() {
        AudioSource audio = GetComponent<AudioSource>();
        Data data = GameObject.Find("Data").GetComponent<Data>(); ;
        while (true) {
            yield return new WaitForSeconds(waitTime);
            Instantiate(bullet, transform.position, Quaternion.identity);
            if (data.sound == 1) {
                audio.Play();
            }
        }
    }
}
