using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushEnter : MonoBehaviour {
    float changeRed = 1.0f;
    float changeGreen = 0;
    float changeBlue = 0;
    float chageAlpha = 1.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            chageAlpha = 0;
        }
        else
        {
            chageAlpha = 1.0f;
        }

        this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, changeBlue, chageAlpha);
    }
}
