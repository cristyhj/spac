using UnityEngine;
using System.Collections;

public class nScreenSettings : MonoBehaviour {

    static private bool firstTime = true;

    void Start() {
        if (firstTime) {
            firstTime = false;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}
