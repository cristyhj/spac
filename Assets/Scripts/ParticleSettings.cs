using UnityEngine;
using System.Collections;

public class ParticleSettings : MonoBehaviour {

//	private ParticleSystem particle;
	
	void Start () {
		//particle = GetComponent<ParticleSystem>();
		StartCoroutine(DestroyMyself());
	}

	IEnumerator DestroyMyself() {
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
	
	void Update () {
	
	}
}
