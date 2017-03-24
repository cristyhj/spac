using UnityEngine;
using System.Collections;

public class BrownianMove : MonoBehaviour {

	public float maxSpeed;
	private Vector2 move;
	private Rigidbody2D rigidBody;
	private Vector2 increase;
    public GameObject bullet;
	
	private float startTime = 0f;
	public float maxTimeLapse = 1f;

	// Use this for initialization
	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		increase = Random.insideUnitCircle / 10;
		move = Random.insideUnitCircle;
        StartCoroutine(Shoot());
	}

	// Update is called once per frame
	void Update() {
		move += increase;

		if (move.x >= 1 || move.x <= -1) {
			increase.x *= -1;
		}
		if (move.y >= 1 || move.y <= -1) {
			increase.y *= -1;
		}

		if (Time.time > startTime) {
			increase = Random.insideUnitCircle / 10;
			startTime += Random.Range(0f, maxTimeLapse);
		}
	}

    IEnumerator Shoot() {
        while  (true) {
            yield return new WaitForSeconds(1f);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }

	void FixedUpdate() {
		rigidBody.velocity = new Vector2(move.x * maxSpeed, move.y * maxSpeed);
	}

}
