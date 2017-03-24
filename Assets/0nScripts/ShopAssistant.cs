using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopAssistant : MonoBehaviour {

    public Text starsTextGlobal;
    public GameObject selectedSkin;

    void Awake() {
        selectedSkin.GetComponent<Image>().sprite = Resources.Load<Sprite>(PlayerPrefs.GetString("currentSkin")) as Sprite;
        starsTextGlobal.text = PlayerPrefs.GetInt("stars").ToString();
    }
}
