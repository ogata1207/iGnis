using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilSlider : MonoBehaviour
{
    Slider _OilSlider;
    Cell _cell;
    private GameObject Player;
    bool OilSlideF;
    int OilSlidetimer;
    float w1;
    float h1;
    // Use this for initialization
    void Start()
    {
        w1 = 160.0f;
        h1 = 20.0f;
        Player = GameObject.Find("Player");
        OilSlideF = false;
        OilSlidetimer = 0;
        _OilSlider = GameObject.Find("OilSlider").GetComponent<Slider>();
        _cell = GameObject.Find("Player").GetComponent<Cell>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Player.GetComponent<Cell>().OilSliderOk = true;
        }

        _OilSlider.value = (float)_cell.GetOil();

        if (Player.GetComponent<Cell>().OilSliderOk) OilSlidetimer++;
        if (OilSlidetimer > 1 + 1)
        {
            w1 = 250.0f;
            h1 = 25.0f;
            if (OilSlidetimer > 2 + 5)
            {
                w1 = 270.0f;
                h1 = 30.0f + 0.5f;
                if (OilSlidetimer > 3 + 5)
                {
                    w1 = 290.0f;
                    h1 = 35.0f + 0.5f;
                    if (OilSlidetimer > 4 + 5)
                    {
                        w1 = 270.0f;
                        h1 = 30.0f + 0.5f;
                        if (OilSlidetimer > 5 + 5)
                        {
                            w1 = 250.0f;
                            h1 = 25.0f + 0.5f;
                            if (OilSlidetimer > 6 + 5)
                            {
                                w1 = 160.0f;
                                h1 = 20.0f;
                                OilSlidetimer = 0;
                                Player.GetComponent<Cell>().OilSliderOk = false;
                            }
                        }
                    }
                }

            }
        }

        _OilSlider.GetComponent<RectTransform>().sizeDelta = new Vector2(w1, h1);

    }
}
