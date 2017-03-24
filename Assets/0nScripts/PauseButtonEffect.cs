using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButtonEffect : MonoBehaviour {

    public Sprite paused;
    public Sprite notPaused;

    private Data data;

    public GameObject pauseMenu;

    void Start() {
        data = GameObject.Find("Data").GetComponent<Data>();
        if (data == null) {
            Debug.Log("Nu am gasit Data component");
        }
    }

    void Update() {
        if (data.paused == 1) {
            GetComponent<Image>().sprite = paused;
            pauseMenu.SetActive(true);
        } else {
            GetComponent<Image>().sprite = notPaused;
            pauseMenu.SetActive(false);
        }
    }
}
