using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

public class baibu : MonoBehaviour
{

    PlayerIndex playerIndex;
    //private int Timer = 60;
    public float Power = 0f;
    public void SetPower(float p)
    {
        Power = p;
    }

    //public void Play(float time, float p)
    //{
    //    Power = p;
    //    StartCoroutine( Coroutine( time, Power ) );
    //}
    // Use this for initialization
    void Start()
    {

    }

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //パワーを0にしないと一生揺れる
        GamePad.SetVibration(playerIndex, Power, Power);
        //if (Input.GetButtonDown("Start")) StartCoroutine(Coroutine(1));
    }

    IEnumerator Coroutine(float power = 0.1f, float time = 0.1f)
    {
        Power = power;

        float StartTime = Time.time;
        float NowTime = 0;

        while (NowTime < time)
        {
            Power = power;
            NowTime = Time.time - StartTime;
            yield return null;
        }

        //これやらんと一生震えてる
        Power = 0.0f;
    }

    public void Play(float power = 0.1f, float time = 0.1f)
    {
        StartCoroutine(Coroutine(power, time));
    }

}