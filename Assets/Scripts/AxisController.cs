using UnityEngine;
using System.Collections;

public class AxisController : MonoBehaviour {

	private float maxSpeed = 10f;
	private Animator playerAnimator;
	private Vector2 move;
	private Rigidbody2D rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
	}

	void Update() {
		move.x = Input.GetAxis("Horizontal") * maxSpeed;
		move.y = Input.GetAxis("Vertical") * maxSpeed;

		playerAnimator.SetFloat("playerSpeed", move.x * maxSpeed);
	}

	void FixedUpdate() {
		rigidBody.velocity = move;
	}
}
