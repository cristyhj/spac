using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D player;
	public ParticleSystem particles;
	public float maxSpeed = 10f;
	public Vector2 move;

	public AudioClip spacSound;
	private SoundEffetsScript soundControl;
	public GameObject bullet;
	private int shoots;
	public Text shootsText;

	public bool playOnComputer;

	void Start() {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("currentSkin", "skin3")) as Sprite;
        player = GetComponent<Rigidbody2D>();
		shoots = 0;
		UpdateShoots();
		soundControl = FindObjectOfType<SoundEffetsScript>();
	}

	void Update() {
		if (playOnComputer) {
			move.x = Input.GetAxis("Horizontal") * maxSpeed;
			move.y = Input.GetAxis("Vertical") * maxSpeed;
		} else {
			move.x = Input.acceleration.x * maxSpeed * 2.5f;
			move.y = Input.acceleration.y * maxSpeed * 2.5f;
		}
		if (shoots > 0) {
			if (Input.GetMouseButtonDown(0)) {
				Vector2 move = Input.mousePosition;
				move.x -= transform.position.x;
				move.y -= transform.position.y;
				move.Normalize();
				soundControl.Play(1);
				Instantiate(bullet, transform.position, Quaternion.identity);
				shoots--;
				UpdateShoots();
			}
		}
	}

	void FixedUpdate() {
		player.velocity = move;
	}

	

	void UpdateShoots() {
		if (shoots == 0) {
			shootsText.text = "";
			return;
		}
		shootsText.text = shoots.ToString();
	}
}
