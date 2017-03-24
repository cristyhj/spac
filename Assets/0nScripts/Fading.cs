using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fading : MonoBehaviour {

    void Start() {

        Image im = GetComponent<Image>();
        if (im != null) {
            im.CrossFadeAlpha(0f, 0f, false);
            im.CrossFadeAlpha(1f, 3f, false);
            return;
        }
        
        Text tx = GetComponent<Text>();
        if (tx != null) {
            tx.CrossFadeAlpha(0f, 0f, false);
            tx.CrossFadeAlpha(1f, 3f, false);
            return;
        }
    }
}
