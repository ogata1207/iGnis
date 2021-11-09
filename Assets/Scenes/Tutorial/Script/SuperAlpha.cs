using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAlpha : MonoBehaviour
{

    float changeRed = 0.0f;
    float changeGreen = 0.0f;
    float changeBlue = 0.0f;
    float chageAlpha = 1.0f;
    bool StartF;
    bool f;
    public GameObject TextBox;
    // Use this for initialization
    void Start()
    {
        StartF = true;
        f = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartF) chageAlpha -= 0.05f;

        if (TextBox == null)
        {
            StartF = false;
            f = true;
        }
        if (f) chageAlpha += 0.01f;

        this.GetComponent<SpriteRenderer>().color =
            new Color(changeRed, changeGreen, changeBlue, chageAlpha);

    }
}
