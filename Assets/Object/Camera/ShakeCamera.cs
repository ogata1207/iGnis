using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour
{
    private GameObject Player;
    private Vector3 offset;
    private float Power = 0.0f;

    //
    private float lowRangeX;
    private float maxRangeX;
    private float lowRangeY;
    private float maxRangeY;

   
    public Vector3 Shake() { return offset;  }
    public void SetShake(float p)
    {
        Power = p;
    }
    public void Stop() { Power = 0; }
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        offset = Player.transform.position - transform.position;
        StartCoroutine(ShakeItOff());

    }

    void Update()
    {
        if (Power <= 0)
        {
            offset.z = -1;
            offset.x = offset.y = 0;
        }
        if(Power > 0)
        {

            float x_val = Random.Range(lowRangeX, maxRangeX);
            float y_val = Random.Range(lowRangeY, maxRangeY);
            offset = new Vector3(x_val, y_val, -1);
        }
    }

    IEnumerator ShakeItOff()
    {
        while (true)
        {
            lowRangeY = - Power;
            maxRangeY = + Power;
            lowRangeX = - Power;
            maxRangeX = + Power;
            yield return null;
        }
    }
    IEnumerator ShakeForATime(float power = 1.0f, float time = 1.0f)
    {
        float StartTime = Time.time;
        float NowTime = 0;

        //待機
        while (NowTime < time)
        {
            NowTime = Time.time - StartTime;
            yield return null;
        }

        yield return null;
    }

    public void ShakeShakeShake(float power = 1.0f, float time = 1.0f)
    {
        StartCoroutine(ShakeForATime(power, time));
    }
}