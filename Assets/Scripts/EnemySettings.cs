using UnityEngine;
using System.Collections;

public class EnemySettings : MonoBehaviour {

	public GameObject particles;

	public void PrepareToBeDestroyed() {
		Instantiate(particles, gameObject.transform.position, Quaternion.identity);
	}
	
}
