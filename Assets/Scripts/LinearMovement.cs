using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LinearMovement : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public ParticleSystem particles;
	public Vector2 move;
	public float maxSpeed = 5f;
	
    
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();

		//Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        Vector3 pos = Vector3.zero;
        //foreach (Touch touch in Input.touches) {
        //    pos = touch.position;
        //}
        pos = Input.mousePosition;

        pos = Camera.main.ScreenToWorldPoint(pos);
		pos -= GameObject.Find("Player").transform.position;
		pos.Normalize();
		move.x = pos.x;
		move.y = pos.y;
		
		float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg + 90f;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	void FixedUpdate() {
		rigidBody.velocity = move * maxSpeed;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Enemy3") {
			Destroy(coll.gameObject);
			Instantiate(particles, gameObject.transform.position, Quaternion.identity);
		}
		if (coll.gameObject.tag != "Player" && coll.gameObject.tag != "Bullet") {
			Destroy(gameObject);
		}
	}
}
