using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAlpha : MonoBehaviour {
    float changeRed = 0.0f;
    float changeGreen = 0.0f;
    float changeBlue = 0.0f;
    float chageAlpha = 0.0f;
    bool f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire2")) f = true;
        if (f) chageAlpha += 0.01f;

        this.GetComponent<SpriteRenderer>().color = 
            new Color(changeRed, changeGreen, changeBlue, chageAlpha);

    }
}
