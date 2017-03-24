using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigid;
    public float maxSpeed;
    private Vector2 move;


    void Awake() {
         GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("currentSkin", "basic")) as Sprite;
    }
    void Start() {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Application.isEditor) {
            move.x = Input.GetAxis("Horizontal") * maxSpeed;
            move.y = Input.GetAxis("Vertical") * maxSpeed;
        } else {
            move.x = Input.acceleration.x * maxSpeed * 2.5f;
            move.y = Input.acceleration.y * maxSpeed * 2.5f;
        }
    }

    void FixedUpdate() {
        rigid.velocity = move;
    }
}
