using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
public class Cell : MonoBehaviour
{

    /////////////////////////
    //  カーソルの色
    /////////////////////////

    public Color NoneModeColor = Color.black;
    public Color FireModeColor = Color.red;
    public Color OilModeColor = Color.blue;

    /////////////////////////
    //  モード関連
    /////////////////////////
    public GameObject OilObj;
    private SpriteRenderer sprite;
    //仮
    private int 着火できる回数 = 1;
    private int オイルを置ける回数 = 10;
    Vector3 MovePower = Vector3.zero;
    private int State = 0;

    public GameObject InstallationEffect;

    public GameObject OilInstallationEffect;

    public bool OilOk;
    public bool FireFrame;

    public bool OilSliderOk;
    enum StateNumber
    {
        None = 0,       //何もしない
        Fire = 1,       //着火モード
        Oil = 2        //オイルモード
    }

    public void SetFire(int num)
    {

        着火できる回数 = num;
    }
    public void AddFire(int num)
    {
        if (着火できる回数 < 0) 着火できる回数 = 0;
        着火できる回数 += num;
        LogManager.AddLog("着火点が増えたマーン", Color.red);
    }

    public int GetFire() { return 着火できる回数; }


    public void SetOil(int num)
    {
        オイルを置ける回数 = num;
    }
    public void AddOil(int num)
    {
        オイルを置ける回数 += num;
        OilSliderOk = true;
        if (OilOk) LogManager.AddLog("オイルが増えたマーン", Color.magenta);
    }
    public int GetOil() { return オイルを置ける回数; }

    // 
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();

    //タイルマップ

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Use this for initialization
    void Start()
    {
        OilSliderOk = false;

        GameManager gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        着火できる回数 = gManager.初期の着火点の数;
        オイルを置ける回数 = gManager.初期のオイルの数;

        //カメラをプレイヤーの動きにあわせて動かすやーつ
        StartCoroutine(PursuitCamera());

        //カーソルのスプライト
        sprite = GetComponent<SpriteRenderer>();

        //カーソルの色を着火モードの色にする
        sprite.color = NoneModeColor;

        //モードを着火モードにする
        State = (int)StateNumber.Fire;

        audioSource = gameObject.AddComponent<AudioSource>();
        FireFrame = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /////////////////////////////////////////////
        //                                           
        //  強制的にモードを変更する
        //
        /////////////////////////////////////////////
        if (着火できる回数 <= 0)
        {
            State = (int)StateNumber.Oil;
            //sprite.color = OilModeColor;
        }


        /////////////////////////////////////////////
        //
        //  ボタンを押したときの処理
        //
        /////////////////////////////////////////////

        if (着火できる回数 > 0 && Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
        if (SceneManager.GetActiveScene().name == "hogehoge")
        { // hogehogeシーンでのみやりたい処理

        }
        if (Input.GetButton("Fire2") && OilOk/*&& SceneManager.GetActiveScene().name == "Main"*/)
        {
            Oil();
        }



        /////////////////////////////////////////////
        //                                           
        //  その他
        //
        /////////////////////////////////////////////


        /////////////////////////////////////////////
        //                                           
        //  デバッグ用
        //
        /////////////////////////////////////////////

        //if (Input.GetKeyDown(KeyCode.I)) AddOil(1);
        //if (Input.GetKeyDown(KeyCode.U)) AddFire(1);
    }


    /////////////////////////////////////////////
    //
    //  プレイヤーがカメラの端で動こうとしたとき
    //　カメラも一緒に動かすやつ
    //
    /////////////////////////////////////////////
    IEnumerator PursuitCamera()
    {
        while (true)
        {
            if (TimeManager.Activate)
            {
                //移動方向を決める

                float x = Input.GetAxisRaw("MoveX");
                float y = Input.GetAxisRaw("MoveY");
                if (x == 0 && y == 0)
                {
                    MovePower = Vector3.zero;
                }
                else if (y > 0)
                {
                    MovePower = Vector3.up;
                    audioSource.PlayOneShot(audioClip[0]);
                }
                else if (y < 0)
                {
                    MovePower = Vector3.down;
                    audioSource.PlayOneShot(audioClip[0]);
                }
                else if (x < 0)
                {
                    MovePower = Vector3.left;
                    audioSource.PlayOneShot(audioClip[0]);
                }
                else if (x > 0)
                {
                    MovePower = Vector3.right;
                    audioSource.PlayOneShot(audioClip[0]);
                }

                //yield return new WaitForSeconds(0.02f);
                //カメラが描画している画面の中心の座標を取る
                Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2(.5f, .5f));

                //画面の中心からプレイヤーの位置をXとY別々で計算
                float FloatlengthX = (transform.position.x + MovePower.x) - pos.x;
                float FloatlengthY = (transform.position.y + MovePower.y) - pos.y;

                //距離をint型に変換
                var IntLengthX = Mathf.CeilToInt(FloatlengthX);
                var IntLengthY = Mathf.CeilToInt(FloatlengthX);

                //カメラの位置によってカメラを動かす場所を変える
                CameraScript cam = Camera.main.GetComponent<CameraScript>();
                int rate = Mathf.CeilToInt(Camera.main.orthographicSize / cam.Size1);

                //上下左右　プレイヤーが画面の中心から一定の距離はなれると
                //プレイヤーの子にメインカメラを入れて同時に移動させる

                if (FloatlengthY >= 3 * rate && MovePower == Vector3.up) Camera.main.transform.position += MovePower;
                if (FloatlengthY <= -3 * rate && MovePower == Vector3.down) Camera.main.transform.position += MovePower;
                if (FloatlengthX <= -6 * rate && MovePower == Vector3.left) Camera.main.transform.position += MovePower;
                if (FloatlengthX >= 6 * rate && MovePower == Vector3.right) Camera.main.transform.position += MovePower;


                GameObject obj = Ray(MovePower, 0);
                //移動
                if (!obj || obj.gameObject.tag != "AreaWall")
                {
                    transform.position += MovePower;
                }
                Camera.main.transform.parent = null;
                yield return new WaitForSeconds(0.08f);

            }
            yield return null;
        }
        yield return null;
    }


    /////////////////////////////////////////////
    //
    //  各モードの関数
    //
    /////////////////////////////////////////////

    //燃やす
    void Fire()
    {
        if (着火できる回数 <= 0) return;
        //自分と同じ座標のオブジェクトを取得
        GameObject g = Ray();

        if (g.tag == "NotBurning")
        {

            //普通に燃えるオブジェクトがある場合
            if (g.GetComponent<NormalCell>() && !g.GetComponent<Oil>())
            {
                FireFrame = true;
                audioSource.PlayOneShot(audioClip[1]);
                GameObject ef = Instantiate(InstallationEffect, transform.position, Quaternion.identity) as GameObject;
                Destroy(ef, 0.2f);
                GameObject shake = GameObject.Find("Main Camera");
                bool flg = shake.GetComponent<CamrraSha>().GetShakeFlg();
                if (!flg) shake.GetComponent<CamrraSha>().CatchShake();
                着火できる回数--;
                g.tag = "Burning";
                g.GetComponent<NormalCell>().FireLevel = 10;
                g.GetComponent<NormalCell>().Burning();
            }

            else
            {
                FireFrame = false;
                audioSource.PlayOneShot(audioClip[3]);
            }
        }
        else if (g.gameObject.tag == "Water")
        {
            FireFrame = false;
            audioSource.PlayOneShot(audioClip[3]);
        }

    }

    //オイル
    void Oil()
    {
        if (オイルを置ける回数 <= 0) return;

        //自分と同じ座標のオブジェクトを取得
        GameObject g = Ray();


        if (g.gameObject.GetComponent<NormalCell>() && !g.gameObject.GetComponent<Oil>() && OilOk)
        {
            if (g.gameObject.tag == "NotBurning" || g.gameObject.tag == "NowBurn" && OilOk)
            {
                audioSource.PlayOneShot(audioClip[2]);
                GameObject ef = Instantiate(OilInstallationEffect, transform.position, Quaternion.identity) as GameObject;
                Destroy(ef, 0.2f);
                GameObject shake = GameObject.Find("Main Camera");
                bool flg = shake.GetComponent<CamrraSha>().GetShakeFlg();
                if (!flg) shake.GetComponent<CamrraSha>().CatchShake();
                GameObject oil = Instantiate(OilObj, transform);
                oil.transform.parent = GameObject.Find("Grid").transform;

                //if (!g.GetComponent<Oil>()) TileMapTest.Num--;
                Destroy(g.gameObject);
                オイルを置ける回数--;
            }
        }

       else if (g.gameObject.tag == "Water" && OilOk)
        {
            audioSource.PlayOneShot(audioClip[2]);
            GameObject ef = Instantiate(OilInstallationEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(ef, 0.2f);
            GameObject shake = GameObject.Find("Main Camera");
            bool flg = shake.GetComponent<CamrraSha>().GetShakeFlg();
            if (!flg) shake.GetComponent<CamrraSha>().CatchShake();
            GameObject oil = Instantiate(OilObj, transform);
            oil.transform.parent = GameObject.Find("Grid").transform;
            GameManager.燃えるマスの最大数++;
            if (!g.GetComponent<Oil>()) TileMapTest.Num++;
            Destroy(g.gameObject);
            オイルを置ける回数--;
        }

    }

    /////////////////////////////////////////////
    //
    //  レイ関連
    //
    /////////////////////////////////////////////
    GameObject Ray(Vector2 dir, float dist)
    {

        RaycastHit2D hit;
        //GameObject ob = new GameObject();

        //
        Vector3 RayPos = transform.position + new Vector3(dir.x, dir.y, 0);
        hit = Physics2D.Raycast(RayPos, dir, dist);
        Debug.DrawRay(RayPos, dir * dist, Color.blue, .5f);

        if (hit) return hit.collider.gameObject;
        else return null;
        //else return ob;
    }

    //  同じ座標のオブジェクトを取得
    //  自分と同じ座標にあるオブジェクトを取得
    GameObject Ray()
    {
        return Ray(new Vector3(0, 0, 0), 0);
    }

    //  自分と同じ座標にいるオブジェクトがあるか調べる
    //  同じ座標になにかオブジェクトがあるときはTRUE
    //  なければFALSE

    bool Check()
    {
        RaycastHit2D hit;
        //
        Vector3 RayPos = transform.position + new Vector3(0, 0, 0);
        hit = Physics2D.Raycast(RayPos, new Vector3(0, 0, 0), 0);
        Debug.DrawRay(RayPos, new Vector3(0, 0, 0) * 0, Color.blue, .5f);

        if (!hit) return false;
        return true;
    }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

}


