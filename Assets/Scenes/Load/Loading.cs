using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    private AsyncOperation async;		//　非同期動作で使用するAsyncOperation
    //public Slider slider;			//　読み込み率を表示するスライダー

    [SerializeField, MultilineAttribute(2)]
    string message1 = "ロードするシーンは各シーン毎に設定しないといけない";

    static public string SceneName = "Main";
    static public void SetScene(string sName) { SceneName = sName; }
    void Start()
    {
        Time.timeScale = 1.0f;
        TimeManager.Activate = true;

        //　コルーチンを開始
        StartCoroutine(LoadData());
    }


    IEnumerator LoadData()
    {

        // シーンの読み込みをする
        async = SceneManager.LoadSceneAsync(SceneName);
        async.allowSceneActivation = false;
        yield return new WaitForSeconds(3f);

        async.allowSceneActivation = true;
        yield return null;

    }

}
