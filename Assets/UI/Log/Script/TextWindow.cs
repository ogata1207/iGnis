using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextWindow : MonoBehaviour
{
    //描画用のテキスト
    public Text[] text;
    public float 次の文字までの時間 = 0.05f;


    //台詞
    public string[] Serifu;
    private int TextLength; //台詞の文字数
    public int NowSerifu = 0; //現在の台詞番号
    private int MaxSerifu = 0; //台詞の数

    private bool isUsed = false;
    public bool NextText = true;
    public bool EndFlg = false;

    //public int Stop;
    //bool stop2;
    AudioSource audioSource;
    public GameObject TesPlayer;
    public List<AudioClip> audioClip = new List<AudioClip>();
    //public GameObject PlayerObj;
    //[SerializeField]
    //Fade fade = null;
    //int ChangeTimer;
    //bool ChangeF;
    int NextTimer;
    // Use this for initialization
    void Start()
    {
        //fade.FadeIn(0.1f, () =>
        //{
        //    fade.FadeOut(1);
        //});
        Clear();
        MaxSerifu = Serifu.Length;
        //Time.timeScale = 1.0f;
        //stop2 = false;
        //Stop = 2;
        NextTimer = 0;
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    fade.FadeIn(2);
        //    ChangeF = true;
        //}
        //if (ChangeF) ChangeTimer++;
        //if (ChangeTimer > 60 * 2)
        //{
        //    SceneManager.LoadScene("Main");
        //    //ChangeTimer = 0;
        //}

        //Debug.Log(Stop);
        //NextTimer++;
        //if (NextTimer > 70) Stop = 0;

        //コルーチンが終わると入力を受け付ける
        if (isUsed == false)
        {
            if (/*Input.GetKeyDown(KeyCode.Return) || */Input.GetButtonDown("Fire3") ||
                TesPlayer.GetComponent<PlayerTest>().MoveFlgTimer == 121 ||
                TesPlayer.GetComponent<PlayerTest>().FireTimer == 121 ||
                TesPlayer.GetComponent<PlayerTest>().OilTimer == 121)
            {
                if (NextText == true && MaxSerifu >= NowSerifu)
                {
                    //Time.timeScale = 0;
                    //if (!stop2)
                    //{
                        MoveLog();
                        isUsed = true;
                        StartCoroutine(hoge());
                    //}
                }
                else
                {
                    EndFlg = true;
                    Time.timeScale = 1.0f;
                    Destroy(gameObject);
                }
            }



            //************************************************************************************
        }
        //******************************************************************
        //
        //      Gorioshi
        //
        //******************************************************************
        ////移動説明
        //if (NowSerifu == 4)
        //{
        //    Stop = 1;
        //    stop2 = true;
        //    if (TesPlayer.GetComponent<PlayerTest>().MoveFlgTimer == 60 * 2)
        //    {
        //        //NowSerifu = 5;
        //        NowSerifu++;
        //        Stop = 0;
        //        stop2 = false;
        //    }
        //}

        //// 着火説明
        //if (NowSerifu == 7)
        //{
        //    Stop = 1;
        //    stop2 = true;

        //    if (TesPlayer.GetComponent<PlayerTest>().FireTimer == 60 * 2)
        //    {
        //        //NowSerifu = 7;
        //        NowSerifu++;
        //        stop2 = false;

        //        Stop = 0;
        //    }
        //}

        ////オイル説明
        //if (NowSerifu == 11)
        //{
        //    Stop = 1;
        //    stop2 = true;

        //    if (TesPlayer.GetComponent<PlayerTest>().OilTimer == 60 * 2)
        //    {
        //        //NowSerifu = 14;
        //        NowSerifu++;
        //        stop2 = false;

        //        Stop = 0;
        //    }
        //}

        //if (NowSerifu == 20)
        //{
        //    Stop = 1;
        //    stop2 = false;
        //}


        //if (Stop == 0) Time.timeScale = 0.0f;
        ////else if (Stop == 0 && NowSerifu > 19) Time.timeScale = 1.0f;
        //else Time.timeScale = 1.0f;

    }

    //テキストの文字1つずつ上にあげる
    void MoveLog()
    {

        for (int i = 2 - 1; i >= 1; i--)
        {
            text[i].text = "" + text[i - 1].text;
        }

    }

    //テキストの中身を全部0文字にする
    public void Clear()
    {

        for (int i = 0; i < 2; i++)
        {
            text[i].text = "";
        }

        //台詞を一番初めに戻す
        NowSerifu = 0;


    }

    //////////////////////////////////////////////////////////
    //https://gist.github.com/uranuno/5678273
    //タイムスケールが0でも動くやつ
    IEnumerator WaitForSecondsIgnoreTimeScale(float time)
    {
        float targetTime = Time.realtimeSinceStartup + time;
        while (Time.realtimeSinceStartup < targetTime)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    //////////////////////////////////////////////////////////
    IEnumerator hoge()
    {

        isUsed = true;
        TextLength = Serifu[NowSerifu].Length;
        for (int i = 0; i <= TextLength; i++)
        {
            text[0].text = Serifu[NowSerifu].Substring(0, i);
            audioSource.PlayOneShot(audioClip[0]);
            yield return StartCoroutine(WaitForSecondsIgnoreTimeScale(次の文字までの時間));
            //yield return new WaitForSeconds((TextSpeed));
        }

        NowSerifu++;
        //次の台詞がある場合
        if (MaxSerifu != NowSerifu)
        {

            NextText = true;

        }
        else //ない場合
        {
            NextText = false;
        }
        isUsed = false;
        yield return null;
    }
}
