using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	void Start () {
		Camera cam = GetComponent<Camera>();
		cam.backgroundColor = Random.ColorHSV();
	}
	
}
