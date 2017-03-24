using UnityEngine;
using System.Collections;

public class ScreenSettings : MonoBehaviour {

	void Awake() {
		GetComponent<Camera>().aspect = Screen.width / Screen.height;
	}

}
