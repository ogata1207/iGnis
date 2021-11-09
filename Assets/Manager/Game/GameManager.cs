using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    //[SerializeField]
    //Fade fade = null;
    //int ChangeTimer;
    //bool ChangeF;

    public float ゲーム時間;
    public int 初期の着火点の数;
    public int 初期のオイルの数;

    public float[] NormalBurnTime;
    private float[] sNormalBurnTime;
    public float[] ForestBurnTime;
    public float Occupancy; //占有率
    public int 風で燃え移るマスの長さ = 2;
    public Text 風の向きが変わるまでの時間のてきすと;
    public float 倍速 = 2;
    public int 風の向きが変わるまでの時間 = 10;
    public Vector2 WindDir = Vector2.zero;
    public Vector2 NextWind = Vector2.zero;
    public int NextWindNumber = 0;
    public void WindToUp() { WindDir = Vector2.up; }
    public void WindToDown() { WindDir = Vector2.down; }
    public void WindToRight() { WindDir = Vector2.right; }
    public void WindToLeft() { WindDir = Vector2.left; }
    public void WindToAll() { WindDir = Vector2.zero; }
    static public int 燃えるマスの最大数 = 0;
    private int WindChangeTime;
    public void SetWindChangeTime(int time) { WindChangeTime = time; }
    public bool デバッグ用風情報表示 = true;

    void SetScale(float t) { Time.timeScale = t; }

    // Use this for initialization
    IEnumerator Start()
    {
        Time.timeScale = 1.0f;
        sNormalBurnTime = NormalBurnTime;
        while (true)
        {
            for( int i=0; i < sNormalBurnTime.Length; i++)
            {
                NormalBurnTime[i] = sNormalBurnTime[i] / Time.timeScale;
                yield return null;
            }
            yield return null;
        }
    }
    void Update()
    {

        if (燃えるマスの最大数 < TileMapTest.Num) 燃えるマスの最大数 = TileMapTest.Num;

        Occupancy = (1.0f - ((float)TileMapTest.Num / (float)燃えるマスの最大数)) * 100;
        if (デバッグ用風情報表示) 風の向きが変わるまでの時間のてきすと.text = "Time:" + EventManager.time.ToString("F0") + " NextWindNumber: " + NextWindNumber + " Dir:" + WindDir;


        if (Input.GetButton("SpeedUp"))
        {
            SetScale(倍速);
        }
        Debug.Log(Time.timeScale);

    }

    //タイトルに移動したときの処理
    public void Destroy()
    {
        Destroy(gameObject);
    }


}
