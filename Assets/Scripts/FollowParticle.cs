using UnityEngine;
using System.Collections;

public class FollowParticle : MonoBehaviour {

	private GameObject particle;
	private Rigidbody2D rigidBody;
	private Transform trans;
	private Vector2 move;
	public float maxSpeed = 10f;

	void Start () {
		particle = GameObject.FindWithTag("Player");
		rigidBody = GetComponent<Rigidbody2D>();
		trans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		move.x = particle.transform.position.x - trans.position.x;
		move.y = particle.transform.position.y - trans.position.y;

		move.Normalize();
		move *= maxSpeed;
	}

	void FixedUpdate() {
		rigidBody.velocity = move;
	}
}
