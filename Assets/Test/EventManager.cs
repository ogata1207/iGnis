using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventManager : MonoBehaviour
{


    GameManager gManager;

    //
    public Canvas canvas;
    public GameObject obj;
    private int MainMissionState = 0;
    public int MainMission01 = 20;
    public int MainMission02 = 50;
    public int MainMission03 = 100;
    public int ミッション告知時間 = 5;
    public int 報酬獲得時間 = 20;

    public int 風が発生するまでの時間 = 20;
    public int 次の風を告知する時間 = 5;
    public int 風の発生時間 = 10;
    public Vector2[] 風の方向;
    public int WindDirNum;
    static public float time = 0;
    public bool WindOk;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    public bool[] isUsed;
    // Use this for initialization
    void Start()
    {
        //Init
        isUsed = new bool[4];
        WindDirNum = 風の方向.Length;
        for (int i = 0; i < 4; i++) isUsed[i] = false;
        gManager = GetComponent<GameManager>();
        StartCoroutine(Mission01());
        if (gManager.NextWind == Vector2.zero&&WindOk) StartCoroutine(NormalWind());
        else StartCoroutine(WindGen(gManager.NextWind));
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    Vector2 ChangeWindDir(int number)
    {
        switch (number)
        {
            case 0:
                return Vector2.zero;

            case 1:
                return Vector2.up;

            case 2:
                return Vector2.down;

            case 3:
                return Vector2.right;

            case 4:
                return Vector2.left;

        }

        return Vector2.zero;
    }

    int RandomWind(int min, int max)
    {
        return Random.Range(min, max);
        //if ( !isUsed[number-1] ) return number;
        //else return RandomWind(min, max);
    }


    IEnumerator Mission01()
    {
        GameObject ob = Instantiate(obj, canvas.transform);
        ob.transform.Find("Text").GetComponent<Text>().text = "[課題]" + MainMission01 + "%占有せよ";
        yield return new WaitForSeconds(ミッション告知時間);
        Destroy(ob);
        while ((int)gManager.Occupancy <= MainMission01)
        {

            yield return null;
        }

        ob = Instantiate(obj, canvas.transform);
        ob.transform.Find("Text").GetComponent<Text>().text = "[報酬]制限時間が延びました";
        TimeManager.time += 報酬獲得時間;
        yield return new WaitForSeconds(ミッション告知時間);
        Destroy(ob);

        StartCoroutine(Mission02());
        yield return null;
    }

    IEnumerator Mission02()
    {
        GameObject ob = Instantiate(obj, canvas.transform);
        ob.transform.Find("Text").GetComponent<Text>().text = "[課題]" + MainMission02 + "%占有せよ";
        yield return new WaitForSeconds(ミッション告知時間 );
        Destroy(ob);
        while ((int)gManager.Occupancy <= MainMission02)
        {
            yield return null;
        }

        ob = Instantiate(obj, canvas.transform);
        ob.transform.Find("Text").GetComponent<Text>().text = "[報酬]制限時間が延びました";
        TimeManager.time += 報酬獲得時間;
        yield return new WaitForSeconds(ミッション告知時間);
        Destroy(ob);

        StartCoroutine(Mission03());
        yield return null;
    }

    IEnumerator Mission03()
    {
        GameObject ob = Instantiate(obj, canvas.transform);
        ob.transform.Find("Text").GetComponent<Text>().text = "[課題]" + MainMission03 + "%占有せよ";
        yield return new WaitForSeconds(ミッション告知時間);
        Destroy(ob);

        while ((int)gManager.Occupancy <= MainMission03)
        {
            yield return null;
        }

        yield return null;
    }


    IEnumerator NormalWind()
    {
        if (WindOk) {

            // 0 = 通常の風向き
            gManager.WindDir = Vector3.zero;
           
            {
                //発生　→　告知(警告)
                {
                    //どこかに表示するように一応用意したやつ(次の風までの時間)
                    time = 風が発生するまでの時間 + 次の風を告知する時間;

                    //開始時の時間を保存
                    var StartTime = Time.time;

                    //指定の時間までループ
                    while (Time.time - StartTime < 風が発生するまでの時間)
                    {
                        time -= 1 * Time.deltaTime;
                        yield return null;
                    }

                }

                gManager.NextWind = 風の方向[RandomWind(0, WindDirNum)];
                //告知(警告) → 実行(風発生)
                {
                    //開始時の時間を保存
                    var StartTime = Time.time;

                    GameObject ob = Instantiate(obj, canvas.transform);
                    ob.transform.Find("Text").GetComponent<Text>().text = GetWindChar(gManager.NextWind) + "の風が吹きそうです";
                    audioSource.PlayOneShot(audioClip[0]);
                    //指定の時間までループ
                    while (Time.time - StartTime < 次の風を告知する時間)
                    {
                        time -= 1 * Time.deltaTime;
                        yield return null;
                    }

                    Destroy(ob);
                }
            }

        }

        //実行(風発生)
        if(WindOk)StartCoroutine(WindGen(gManager.NextWind));

        yield return null;
    }

    IEnumerator WindGen(Vector2 dir)
    {

        //風向きの変更
        gManager.WindDir = dir;

        // 風発生中　→　風がやむまでの間
        {

            time = 風の発生時間;

            //開始時の時間を保存
            var StartTime = Time.time;

            //指定の時間までループ
            while (Time.time - StartTime < 風の発生時間)
            {
                time -= 1 * Time.deltaTime;
                yield return null;
            }
        }

        //　普通の風に戻す
        StartCoroutine(NormalWind());
        yield return null;
    }

    string GetWindChar(Vector2 dir)
    {

        if (dir == Vector2.up) return "上向き";
        if (dir == Vector2.down) return "下向き";
        if (dir == Vector2.left) return "左向き";
        if (dir == Vector2.right) return "右向き";
        return "全体";
    }
}
