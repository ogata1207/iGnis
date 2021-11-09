using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireSlider : MonoBehaviour
{

    Slider Fireslider1;
    Slider Fireslider2;
    Slider Fireslider3;
    Slider Fireslider4;
    Slider Fireslider5;

    Cell _cell;
    int EffectTimer;
    int EffectTimer2;
    int EffectTimer3;
    int EffectTimer4;
    int EffectTimer5;

    public GameObject Hit;

    Vector3 Pos1;
    Vector3 Pos2;
    Vector3 Pos3;
    Vector3 Pos4;
    Vector3 Pos5;


    bool Fireslider1F;
    int Fireslider1timer;
    float w1;
    float h1;

    bool Fireslider2F;
    int Fireslider2timer;
    float w2;
    float h2;

    bool Fireslider3F;
    int Fireslider3timer;
    float w3;
    float h3;

    bool Fireslider4F;
    int Fireslider4timer;
    float w4;
    float h4;

    bool Fireslider5F;
    int Fireslider5timer;
    float w5;
    float h5;
    void Start()
    {
        Fireslider1F = false;
        Fireslider1timer = 0;
        w1 = 160.0f;
        h1 = 20.0f;

        Fireslider2F = false;
        Fireslider2timer = 0;
        w2 = 160.0f;
        h2 = 20.0f;

        Fireslider3F= false;
        Fireslider3timer = 0;
        w3 = 160.0f;
        h3 = 20.0f;

        Fireslider4F = false;
        Fireslider4timer = 0;
        w4 = 160.0f;
        h4 = 20.0f;

        Fireslider5F = false;
        Fireslider5timer = 0;
        w5 = 160.0f;
        h5 = 20.0f;

        // スライダーを取得する
        Fireslider1 = GameObject.Find("FireCount1").GetComponent<Slider>();
        Fireslider2 = GameObject.Find("FireCount2").GetComponent<Slider>();
        Fireslider3 = GameObject.Find("FireCount3").GetComponent<Slider>();
        Fireslider4 = GameObject.Find("FireCount4").GetComponent<Slider>();
        Fireslider5 = GameObject.Find("FireCount5").GetComponent<Slider>();
        _cell = GameObject.Find("Player").GetComponent<Cell>();
        EffectTimer = 2;

    }

    //if (Input.GetKeyDown(KeyCode.B)/*&& w == 160*/)
    //{
    //    if (w >= 200)
    //    {
    //        w -= 0.1f;
    //    }
    //}


    float Gauge = 0;
    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    Fireslider1F = true;
        //    Fireslider2F = true;
        //    Fireslider3F = true;
        //    Fireslider4F = true;
        //    Fireslider5F = true;
        //}


        if (Fireslider1F) Fireslider1timer++;


        if (_cell.GetFire() >= 1/*&&!test*/)
        {
            Gauge = 1;
            EffectTimer++;
        }
        else
        {
            //test = false;
            Gauge = 0;
            EffectTimer = 0;
        }
        if (EffectTimer == 1)
        {
            Fireslider1F = true;
            Pos1 = Fireslider1.transform.position;
            Pos1.x = -279.88f;
            Pos1.y = 248.633f;
            GameObject ef = Instantiate(Hit, Pos1, Quaternion.identity) as GameObject;
            Destroy(ef, 0.2f);
        }
        Fireslider1.value = Gauge;

        if (Fireslider1timer > 1 + 1)
        {
            w1 = 250.0f;
            h1 = 25.0f;
            if (Fireslider1timer > 2 + 5)
            {
                w1 = 270.0f;
                h1 = 30.0f + 0.5f;
                if (Fireslider1timer > 3 + 5)
                {
                    w1 = 290.0f;
                    h1 = 35.0f + 0.5f;
                    if (Fireslider1timer > 4 + 5)
                    {
                        w1 = 270.0f;
                        h1 = 30.0f + 0.5f;
                        if (Fireslider1timer > 5 + 5)
                        {
                            w1 = 250.0f;
                            h1 = 25.0f + 0.5f;
                            if (Fireslider1timer > 6 + 5)
                            {
                                w1 = 160.0f;
                                h1 = 20.0f;
                                Fireslider1timer = 0;
                                Fireslider1F = false;
                            }
                        }
                    }
                }

            }
        }
        Fireslider1.GetComponent<RectTransform>().sizeDelta = new Vector2(w1, h1);



        if (Fireslider2F) Fireslider2timer++;

        if (_cell.GetFire() >= 2)
        {
            EffectTimer2++;
            Gauge = 1;
        }
        else
        {
            EffectTimer2 = 0;
            Gauge = 0;
        }
        if (EffectTimer2 == 1)
        {
            Fireslider2F = true;
            Pos2 = Fireslider2.transform.position;
            Pos2.x = -279.88f;
            Pos2.y = 249.908f;
            GameObject ef = Instantiate(Hit, Pos2, Quaternion.identity) as GameObject;
            Destroy(ef, 0.2f);
        }
        Fireslider2.value = Gauge;

        if (Fireslider2timer > 1 + 1)
        {
            w2 = 250.0f;
            h2 = 25.0f;
            if (Fireslider2timer > 2 + 5)
            {
                w2 = 270.0f;
                h2 = 30.0f + 0.5f;
                if (Fireslider2timer > 3 + 5)
                {
                    w2 = 290.0f;
                    h2 = 35.0f + 0.5f;
                    if (Fireslider2timer > 4 + 5)
                    {
                        w2 = 270.0f;
                        h2 = 30.0f + 0.5f;
                        if (Fireslider2timer > 5 + 5)
                        {
                            w2 = 250.0f;
                            h2 = 25.0f + 0.5f;
                            if (Fireslider2timer > 6 + 5)
                            {
                                w2 = 160.0f;
                                h2 = 20.0f;
                                Fireslider2timer = 0;
                                Fireslider2F = false;
                            }
                        }
                    }
                }

            }
        }
        Fireslider2.GetComponent<RectTransform>().sizeDelta = new Vector2(w2, h2);



        if (Fireslider3F) Fireslider3timer++;

        if (_cell.GetFire() >= 3)
        {
            EffectTimer3++;
            Gauge = 1;
        }
        else
        {
            Gauge = 0;
            EffectTimer3 = 0;
        }
        if (EffectTimer3 == 1)
        {
            Fireslider2F = true;
               Pos3 = Fireslider3.transform.position;
            Pos3.x = -279.88f;
            Pos3.y = 251.183f;
            GameObject ef = Instantiate(Hit, Pos3, Quaternion.identity) as GameObject;
            Destroy(ef, 0.2f);
        }
        Fireslider3.value = Gauge;

        if (Fireslider3timer > 1 + 1)
        {
            w3 = 250.0f;
            h3 = 25.0f;
            if (Fireslider3timer > 2 + 5)
            {
               w3 = 270.0f;
                h3 = 30.0f + 0.5f;
                if (Fireslider3timer > 3 + 5)
                {
                   w3 = 290.0f;
                    h3 = 35.0f + 0.5f;
                    if (Fireslider3timer > 4 + 5)
                    {
                        w3 = 270.0f;
                        h3 = 30.0f + 0.5f;
                        if (Fireslider3timer > 5 + 5)
                        {
                           w3 = 250.0f;
                            h3 = 25.0f + 0.5f;
                            if (Fireslider3timer > 6 + 5)
                            {
                               w3 = 160.0f;
                                h3 = 20.0f;
                                Fireslider3timer = 0;
                                Fireslider3F = false;
                            }
                        }
                    }
                }

            }
        }
        Fireslider3.GetComponent<RectTransform>().sizeDelta = new Vector2(w3, h3);



        if (Fireslider4F) Fireslider4timer++;
        if (_cell.GetFire() >= 4)
        {
            EffectTimer4++;
            Gauge = 1;
        }
        else
        {
            EffectTimer4 = 0;
            Gauge = 0;
        }
        if (EffectTimer4 == 1)
        {
            Fireslider4F = true;
            Pos4 = Fireslider4.transform.position;
            Pos4.x = -279.88f;
            Pos4.y = 252.458f;
            GameObject ef = Instantiate(Hit, Pos4, Quaternion.identity) as GameObject;
            Destroy(ef, 0.2f);
        }
        Fireslider4.value = Gauge;
        if (Fireslider4timer > 1 + 1)
        {
            w4 = 250.0f;
            h4 = 25.0f;
            if (Fireslider4timer > 2 + 5)
            {
                w4  = 270.0f;
                h4 = 30.0f + 0.5f;
                if (Fireslider4timer > 3 + 5)
                {
                    w4  = 290.0f;
                    h4 = 35.0f + 0.5f;
                    if (Fireslider4timer > 4 + 5)
                    {
                        w4  = 270.0f;
                        h4 = 30.0f + 0.5f;
                        if (Fireslider4timer > 5 + 5)
                        {
                            w4  = 250.0f;
                            h4 = 25.0f + 0.5f;
                            if (Fireslider4timer > 6 + 5)
                            {
                                w4  = 160.0f;
                                h4 = 20.0f;
                                Fireslider4timer = 0;
                                Fireslider4F = false;
                            }
                        }
                    }
                }

            }
        }
        Fireslider4.GetComponent<RectTransform>().sizeDelta = new Vector2(w4, h4);



        if (Fireslider5F) Fireslider5timer++;

        if (_cell.GetFire() >= 5)
        {
            Gauge = 1;
            EffectTimer5++;
        }
        else
        {
            Gauge = 0;
            EffectTimer5 = 0;
        }
        if (EffectTimer5 == 1)
        {
            Fireslider5F = true;
            Pos5 = Fireslider5.transform.position;
            Pos5.x = -279.88f;
            Pos5.y = 253.733f;
            GameObject ef = Instantiate(Hit, Pos5, Quaternion.identity) as GameObject;
            Destroy(ef, 0.2f);
        }
        Fireslider5.value = Gauge;

        if (Fireslider5timer > 1 + 1)
        {
            w5 = 250.0f;
            h5 = 25.0f;
            if (Fireslider5timer > 2 + 5)
            {
               w5 = 270.0f;
                h5 = 30.0f + 0.5f;
                if (Fireslider5timer > 3 + 5)
                {
                    w5 = 290.0f;
                    h5 = 35.0f + 0.5f;
                    if (Fireslider5timer > 4 + 5)
                    {
                        w5 = 270.0f;
                        h5 = 30.0f + 0.5f;
                        if (Fireslider5timer > 5 + 5)
                        {
                            w5 = 250.0f;
                            h5 = 25.0f + 0.5f;
                            if (Fireslider5timer > 6 + 5)
                            {
                                w5 = 160.0f;
                                h5 = 20.0f;
                                Fireslider5timer = 0;
                                Fireslider5F = false;
                            }
                        }
                    }
                }

            }
        }
        Fireslider5.GetComponent<RectTransform>().sizeDelta = new Vector2(w5, h5);
    }
}
