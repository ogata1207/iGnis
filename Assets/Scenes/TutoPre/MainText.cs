using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainText : MonoBehaviour
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


    //AudioSource audioSource;
    //public GameObject TesPlayer;
    //public List<AudioClip> audioClip = new List<AudioClip>();
    //public GameObject PlayerObj;

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



        //コルーチンが終わると入力を受け付ける
        if (isUsed == false)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Fire3"))
            {
                if (NextText == true && MaxSerifu >= NowSerifu)
                {

                    MoveLog();
                    isUsed = true;
                    StartCoroutine(hoge());

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
