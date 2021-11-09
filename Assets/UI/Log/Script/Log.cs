using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{

    //
    static private int WaitNum;    //出力待ちのテキストの数
    private Text hozon;
    public Text[] text;
    private int TextNum;
    private bool isUsed = false;
    //private int TextLength; //台詞の文字数
    //public string[] Serifu;
    //public int NowSerifu = 0; //現在の台詞番号
    public float 次の文字までの時間 = 0.05f;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        //表示するログの数
        TextNum = text.Length;
        LogManager.Init();
        //ログを空にする
        Clear();
    }

    //nのログをn+1にコピーする
    void MoveLog()
    {

        for (int i = TextNum - 1; i >= 1; i--)
        {
            text[i].text = "" + text[i - 1].text;
            text[i].color = text[i - 1].color;
        }

    }

    public void AddLog(string moji, Color c)
    {
        if (c == Color.clear) c = Color.white;
        StartCoroutine(一文字ずつ出すやつ(moji, c));

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
    IEnumerator 一文字ずつ出すやつ(string moji, Color color)
    {

        var TextLength = moji.Length;
        if (isUsed) WaitNum++;
        while (isUsed) yield return null;
        isUsed = true;
        MoveLog();
        text[0].color = color;
        for (int i = 0; i <= TextLength; i++)
        {
            text[0].text = moji.Substring(0, i);

            yield return StartCoroutine(WaitForSecondsIgnoreTimeScale(次の文字までの時間));
        }

        isUsed = false;
        yield return null;
    }


    public void Clear()
    {

        for (int i = 0; i < TextNum; i++)
        {
            text[i].text = "";
        }
    }
    public void FontColor(float r, float g, float b, float a)
    {
        for (int i = 0; i < TextNum; i++)
        {
            text[i].color = new Color(r, g, b, a);
        }
    }

}



static public class LogManager
{
    static private GameObject Instance;
    static public void Init() { Instance = GameObject.FindWithTag("GameLog"); }
    static public void Update()
    {

    }
    //オンオフ(表示&非表示)の切り替え
    static public void Toggle() { Instance.SetActive(!Instance.active); }
    //ログを消す
    static public void Clear() { Instance.GetComponent<Log>().Clear(); }

    //文字を入れる
    static public void AddLog(string log, Color c = new Color()) { Instance.GetComponent<Log>().AddLog(log, c); }

    //色を変える
    static public void FontColor(float r, float g, float b, float a) { Instance.GetComponent<Log>().FontColor(r, g, b, a); }
}