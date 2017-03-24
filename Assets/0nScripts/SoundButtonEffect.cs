using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SoundButtonEffect : MonoBehaviour {

    public Sprite soundON;
    public Sprite soundOFF;

    private Data data;
    
    void Start() {
        data = GameObject.Find("Data").GetComponent<Data>();
        if (data == null) {
            Debug.Log("Nu am gasit Data component");
        }
    }
    
    void Update () {
        if (data.sound == 1) {
            GetComponent<Image>().sprite = soundON;
        } else {
           GetComponent<Image>().sprite = soundOFF;
        }
    }
}
