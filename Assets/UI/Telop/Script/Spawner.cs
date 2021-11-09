using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject commentPrefab;
    public float interval;
    public Vector3 pos;
    private bool flg;
    private string t;
    public void Set(string txt) { t = txt; }
    void Awake()
    {
    }
    IEnumerator Start()
    {
        t = "てすとえすておうそてすと";
        flg = true;
        while (flg)
        {
            
            transform.position =  pos;
            commentPrefab.GetComponent<Telop>().text = t;
            GameObject g = Instantiate(commentPrefab, transform.position, transform.rotation);
            g.GetComponent<Text>().text = t;
            yield return new WaitForSeconds(interval);
        }
    }

    void Update()
    {
        
        if( Input.GetKeyDown( KeyCode.V)) { flg = false; }
        if (!flg && Input.GetKeyDown(KeyCode.B)) { StartCoroutine(Start()); }
        //if (Input.GetKeyDown(KeyCode.N)) { TelopManager.Set("aaaa" + Time.deltaTime); }


    }

}

static public class TelopManager
{
    static private GameObject Instance;
    static private string text;
    static private float DestroyTime;
    static public void Init()
    {
        Instance = GameObject.FindWithTag("Telop");
        text = "";
        DestroyTime = 20.0f;
    }
    static public void Update()
    {

    }
    //オンオフ(表示&非表示)の切り替え
    static public void Toggle() { Instance.SetActive(!Instance.active); }
    //文字
    static public string GetText() { return text; }
    static public void SetText(string txt) { text = txt; }
    //消去するまでの時間
    static public void SetTime(float time) { DestroyTime = time; }
    static public float GetTime() { return DestroyTime; }
}
