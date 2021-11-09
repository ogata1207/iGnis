using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    #region 定義
    public GameObject obj;
    public GameObject Panel;
    public GameObject Menu1;
    public GameObject Menu2;
    public GameObject Menu3;

    private PauseText[] t;
    private int State = 0;
    private bool Active = false;
    float timeScale = 1.0f;
    public string SceneName;
    private int AxisState = 0;  //Axisキーを押し込んでいるかどうか
    //[SerializeField]
    //Fade fade = null;

    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    #endregion

    // Use this for initialization
    IEnumerator Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        Close();

        yield return new WaitForSeconds(0.5f);

        StartCoroutine(foo());

    }

    // Update is called once per frame

    IEnumerator WaitForSecondsIgnoreTimeScale(float time)
    {
        float targetTime = Time.realtimeSinceStartup + time;
        while (Time.realtimeSinceStartup < targetTime)
        {
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator foo()
    {
        float AxisY;
        GameObject p = GameObject.Find("Player");
        Cell player = p.GetComponent<Cell>();

        while (true)
        {
            //
            // ポーズメニューを開いている間はTimeScaleが0になるのでゲームの進行(時間)が停止するようになってる
            // キー入力ができない状態になってしまうので一時的にTimeScaleを1にして入力を受け付ける
            // 一周回ると一番したでTimeScaleが0になるのでこのコルーチン以外でTimeScaleが1になることはない
            //

            Time.timeScale = 0.0f;
            TimeManager.Activate = false;

            //ポーズメニューを開くボタン(仮) 
            if (Input.GetButtonDown("Pause"))
            {
                audioSource.PlayOneShot(audioClip[0]);
                Toggle();
            }

            if (Active)
            {
                #region キー入力
                //Axisキーの入力
                AxisY = Input.GetAxisRaw("MoveY");
                Debug.Log("KeyAxis:" + AxisY);
                //キーの状態
                if (AxisY == 0) AxisState = 0;

                #endregion
                #region 各キーのあれやこれや
                //上向き
                if (State > 0 && AxisY >= 0.1f)
                {
                    State--;
                    Change();
                    audioSource.PlayOneShot(audioClip[1]);
                    yield return StartCoroutine(WaitForSecondsIgnoreTimeScale(0.08f));
                }

                //下向き
                if (State < 2 && AxisY <= -0.1f)
                {

                    State++;
                    Change();
                    audioSource.PlayOneShot(audioClip[1]);
                    yield return StartCoroutine(WaitForSecondsIgnoreTimeScale(0.08f));

                }
                Debug.Log("scale:" + Time.timeScale);
                //決定ボタン
                if (Input.GetButtonDown("PauseSelect"))
                {
                    Decision();
                    audioSource.PlayOneShot(audioClip[0]);
                }
                #endregion
            }

            Time.timeScale = timeScale;
            if (Time.timeScale != 0) TimeManager.Activate = true;
            yield return null;
        }
    }
    void Decision()
    {
        switch (State)
        {
            case 0:
                Toggle();
                break;
            case 1:
                //現在と同じステージを呼ぶ
                SceneManager.LoadScene(SceneName);
                break;
            case 2:
                //タイトルに戻る
                SceneManager.LoadScene("Title");
                break;

        }
    }

    void Change()
    {
        Vector3 p;
        switch (State)
        {
            case 0:
                p = Panel.transform.position;
                Panel.transform.position = new Vector3(p.x, Menu1.transform.position.y, p.z);
                break;
            case 1:
                p = Panel.transform.position;
                Panel.transform.position = new Vector3(p.x, Menu2.transform.position.y, p.z);
                break;
            case 2:
                p = Panel.transform.position;
                Panel.transform.position = new Vector3(p.x, Menu3.transform.position.y, p.z);
                break;

        }

    }

    void Toggle()
    {

        Active = !Active;
        if (Active) timeScale = 0.0f;
        else timeScale = 1.0f;
        obj.SetActive(Active);
    }
    void Close()
    {
        Active = false;
        timeScale = 1.0f;
        obj.SetActive(Active);
    }

    void Activate()
    {
        Active = true;
        timeScale = 0.0f;
        obj.SetActive(Active);
    }
}
