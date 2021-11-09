using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
    //プレイヤー関連
    private GameObject Player;
    private PlayerMove PlayerScript;
    private Slider PlayerChargeSlider;
    //ログ
    private GameObject GameLog;


	// Use this for initialization
	void Start ()
    {
        LogManager.Init();
        TelopManager.Init();
        GameLog = GameObject.FindWithTag("GameLog");

        //初期設定
        TelopManager.SetTime(15);

	}
	
	// Update is called once per frame
	void Update () {

        //ログ
        if (Input.GetKeyDown(KeyCode.O))
        {
            TelopManager.Toggle();
            LogManager.Toggle();
        }

        if (Input.GetKeyDown(KeyCode.U)) { TelopManager.SetText(Time.deltaTime.ToString()); }

    }
}


