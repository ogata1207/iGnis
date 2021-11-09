using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStage1kara2 : MonoBehaviour
{
    [SerializeField]
    Fade fade = null;
    int ClearChangeTimer;
    bool ClearChangeF;
    int OverChangeTimer;
    bool OverChangeF;

    int OverTimer;
    int ClearTimer;

    public string ClearName;
    public string OverName;

    void Start()
    {
        Time.timeScale = 1.0f;
        fade.FadeIn(0.0f, () =>
        {
            fade.FadeOut(1);
        });
        ClearChangeTimer = 0;
        ClearChangeF = false;

        OverChangeTimer = 0;
        OverChangeF = false;

        OverTimer = 0;
        ClearTimer = 0;
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    SceneManager.LoadScene("Stage1");
        //}
        //if (TimeManager.time <= 0) Over = true;
        //else if (TileMapTest.Num <= 1000) Clear = true;
        //ゲームクリア
        {
            if (TileMapTest.Num <= 0)
            {
                ClearTimer++;
            }
            if (ClearTimer == 60 * 2)
            {
                fade.FadeIn(2);
                ClearChangeF = true;
            }
            if (ClearChangeF) ClearChangeTimer++;
            if (ClearChangeTimer > 60 * 3)
            {
                //ロード画面を挟むからここで設定
                Loading.SceneName = ClearName;
                SceneManager.LoadScene(ClearName);
            }
        }

        // ゲームオーバー
        {
            if (TimeManager.time == 0)
            {
                OverTimer++;
            }
            if (OverTimer == 60 * 2)
            {
                fade.FadeIn(2);
                OverChangeF = true;
            }
            if (OverChangeF) OverChangeTimer++;
            if (OverChangeTimer > 60 * 3)
            {
                SceneManager.LoadScene(OverName);
            }
        }
    }
}
