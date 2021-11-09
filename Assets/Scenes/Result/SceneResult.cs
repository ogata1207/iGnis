using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResult : MonoBehaviour {

    [SerializeField]
    Fade fade = null;
    int ChangeTimer;
    bool ChangeF;

    void Start()
    {
        fade.FadeIn(0.0f, () =>
        {
            fade.FadeOut(1);
        });
        ChangeTimer = 0;
        ChangeF = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Fire3"))
        {
            fade.FadeIn(2);
            ChangeF = true;
        }
        if (ChangeF) ChangeTimer++;
        if (ChangeTimer > 60 * 2)
        {
            //ロード画面を挟むからここで設定
            Loading.SceneName = "Title";
            SceneManager.LoadScene("Loading");
            //ChangeTimer = 0;
        }
    }
}
