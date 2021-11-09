using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aerat : MonoBehaviour {

    public Image test;

    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float changeBlue = 1.0f;
    float chageAlpha = 0.0f;
    // Use this for initialization
    void Start()
    {

        test = GetComponent<Image>();

        //test.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TileMapTest.Num <= 0)
        {
            chageAlpha = 1.0f;
            Destroy(gameObject, 3.0f);
        }
        test.color = new Color(changeRed, changeGreen, changeBlue, chageAlpha);
    }
}
