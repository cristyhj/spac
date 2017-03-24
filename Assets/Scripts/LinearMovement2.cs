using UnityEngine;
using System.Collections;

public class LinearMovement2 : MonoBehaviour {

    private Rigidbody2D rigidBody;
    public ParticleSystem particles;
    public Vector2 move;
    public float maxSpeed = 5f;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();

        float angle = Random.Range(0, 360);

        move = Vector2.up;
        move = Quaternion.AngleAxis(angle, Vector3.forward) * move;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate() {
        rigidBody.velocity = move * maxSpeed;
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player") {
            Instantiate(particles, gameObject.transform.position, Quaternion.identity);
        }
        if (coll.gameObject.tag != "Enemy2" && coll.gameObject.tag != "Bullet") {
            Destroy(gameObject);
        }
    }
}
