using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAlpha : MonoBehaviour {
    EventManager eManager;
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float changeBlue = 1.0f;
    float chageAlpha = 1.0f;
    // Use this for initialization
    void Start () {
        eManager = GameObject.Find("GameManager").GetComponent<EventManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (eManager.風の発生時間 <= 2) chageAlpha -= 0.1f;
        this.GetComponent<SpriteRenderer>().color =
            new Color(changeRed, changeGreen, changeBlue, chageAlpha);

    }
}
