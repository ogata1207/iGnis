using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureNum : MonoBehaviour {
    public Text TemperaturText;
    static public float Num = 0;
    public float MaxFontSize = 60.0f;
    private bool MotionFlg = false;
    public void AddPoint(float p)
    {
        Num = Num + p;
        if (!MotionFlg) StartCoroutine(Add());
    }

    // Use this for initialization
    void Start () {
        TemperaturText.text = "0";

    }

    // Update is called once per frame
    void Update () {
        TemperaturText.text = "" + Num.ToString();
    }

    IEnumerator Add()
    {
        int TextSize = TemperaturText.fontSize;
        MotionFlg = true;
        while (TemperaturText.fontSize < MaxFontSize)
        {
            TemperaturText.fontSize += 10;
            yield return null;
        }


        while (TemperaturText.fontSize > TextSize)
        {
            TemperaturText.fontSize -= 10;
            yield return null;
        }
        TemperaturText.fontSize = TextSize;
        MotionFlg = false;
    }
}
