using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverFlash : MonoBehaviour {

    public Image OverFrame;

    float changeRed = 1.0f;
    float changeGreen = 0.0f;
    float changeBlue = 0.0f;
    float chageAlpha = 0.0f;
    int AlphaTimer;
    bool f;
    bool f2;
    // Use this for initialization
    void Start()
    {
        OverFrame = GetComponent<Image>();
        f = false;
        f2 = false;
        AlphaTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 伝説のタイマー処理発動!!!・・・。使用せずに済んだ。
        //if (Input.GetKeyDown(KeyCode.K)) f = true;
        if (TimeManager.time <= 0) f = true;
        if (f && !f2)
        {
            chageAlpha = 1.0f;
            f2 = true;
            f = false;
        }
        if (f2) chageAlpha -= 0.03f;

        OverFrame.color = new Color(changeRed, changeGreen, changeBlue, chageAlpha);

    }
}
