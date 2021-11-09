using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTest : MonoBehaviour
{

    /////////////////////////
    //  カーソルの色
    /////////////////////////

    public Color NoneModeColor = Color.black;
    public Color FireModeColor = Color.red;
    public Color OilModeColor = Color.blue;
    public GameObject TextObj;
    /////////////////////////
    //  モード関連
    /////////////////////////
    public GameObject OilObj;
    private SpriteRenderer sprite;
    //仮
    private int 着火できる回数 = 1;
    private int オイルを置ける回数 = 10;

    public int 移動説明 = 4;
    public int 着火説明 = 5;
    public int オイル説明 = 7;
    public int 切り替え説明 = 12;

    Vector3 MovePower = Vector3.zero;

    //おれれれ
    public bool MoveFlg;
    public int MoveFlgTimer;
    bool FireTimerFlg;
    public int FireTimer;
    bool OilTimerFlg;
    public int OilTimer;

    private int State = 0;
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
    }
    public int GetFire() { return 着火できる回数; }


    public void SetOil(int num)
    {
        オイルを置ける回数 = num;
    }
    public void AddOil(int num)
    {
        オイルを置ける回数 += num;
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

        GameManager gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        着火できる回数 = gManager.初期の着火点の数;
        オイルを置ける回数 = gManager.初期のオイルの数;

        //カメラをプレイヤーの動きにあわせて動かすやーつ
        StartCoroutine(PursuitCamera());

        //カーソルのスプライト
        sprite = GetComponent<SpriteRenderer>();

        //カーソルの色を着火モードの色にする
        sprite.color = FireModeColor;

        //モードを着火モードにする
        State = (int)StateNumber.Fire;

        MoveFlg = false;
        MoveFlgTimer = 0;
        FireTimerFlg = false;
        FireTimer = 0;
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        /////////////////////////////////////////////
        //                                           
        //  強制的にモードを変更する
        //
        /////////////////////////////////////////////
        if (着火できる回数 <= 0)
        {
            State = (int)StateNumber.Oil;
            sprite.color = OilModeColor;
        }


        /////////////////////////////////////////////
        //
        //  手動でモードを変更する
        //
        /////////////////////////////////////////////

        else if (/*Input.GetKeyDown(KeyCode.Q)*/Input.GetButtonDown("Change") &&
            TextObj.GetComponent<TextWindow>().NowSerifu >= 切り替え説明)
        {
            audioSource.PlayOneShot(audioClip[0]);
            switch (State)
            {
                case (int)StateNumber.Fire:
                    State = (int)StateNumber.Oil;
                    sprite.color = OilModeColor;
                    break;

                case (int)StateNumber.Oil:
                    State = (int)StateNumber.Fire;
                    sprite.color = FireModeColor;
                    break;
                default:
                    break;
            }
        }

        /////////////////////////////////////////////
        //
        //  ボタンを押したときの処理
        //
        /////////////////////////////////////////////
        if (MoveFlg)
        {
            MoveFlgTimer++;
        }

        if (Input.GetButtonDown("Fire1") &&
            TextObj.GetComponent<TextWindow>().NowSerifu >= 着火説明)
        {
            FireTimerFlg = true;
            Fire();
        }
        if (FireTimerFlg) FireTimer++;

        if (Input.GetButtonDown("Fire2") &&
            TextObj.GetComponent<TextWindow>().NowSerifu >= オイル説明)
        {
            OilTimerFlg = true;
            Oil();
        }
        if (OilTimerFlg) OilTimer++;

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
            ////移動方向を決める
            //Vector3 MovePower = Vector3.zero;
            ////移動の説明のところまで行ったら移動可能
            //if (TextObj.GetComponent<TextWindow>().NowSerifu >= 移動説明)
            //{
            //    if (Input.GetKeyDown(KeyCode.W))
            //    {
            //        MovePower += Vector3.up;
            //        audioSource.PlayOneShot(audioClip[0]);
            //    }
            //    else if (Input.GetKeyDown(KeyCode.S))
            //    {
            //        MovePower += Vector3.down;
            //        audioSource.PlayOneShot(audioClip[0]);
            //    }
            //    else if (Input.GetKeyDown(KeyCode.A))
            //    {
            //        MovePower += Vector3.left;
            //        audioSource.PlayOneShot(audioClip[0]);
            //    }
            //    else if (Input.GetKeyDown(KeyCode.D))
            //    {
            //        MovePower += Vector3.right;
            //        audioSource.PlayOneShot(audioClip[0]);
            //    }
            //}

            // 移動説明部分かな
            float x = Input.GetAxisRaw("MoveX");
            float y = Input.GetAxisRaw("MoveY");
            if (x == 0 && y == 0)
            {
                MovePower = Vector3.zero;
            }
            else if (y > 0 && TextObj.GetComponent<TextWindow>().NowSerifu >= 移動説明)
            {
                MoveFlg = true;
                MovePower = Vector3.up;
                audioSource.PlayOneShot(audioClip[0]);
            }
            else if (y < 0 && TextObj.GetComponent<TextWindow>().NowSerifu >= 移動説明)
            {
                MoveFlg = true;
                MovePower = Vector3.down;
                audioSource.PlayOneShot(audioClip[0]);
            }
            else if (x < 0 && TextObj.GetComponent<TextWindow>().NowSerifu >= 移動説明)
            {
                MoveFlg = true;
                MovePower = Vector3.left;
                audioSource.PlayOneShot(audioClip[0]);
            }
            else if (x > 0 && TextObj.GetComponent<TextWindow>().NowSerifu >= 移動説明)
            {
                MoveFlg = true;
                MovePower = Vector3.right;
                audioSource.PlayOneShot(audioClip[0]);
            }

            yield return new WaitForSeconds(0.02f);
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
            if (Camera.main.transform.position.x + MovePower.x < 25 && Camera.main.transform.position.x + MovePower.x > -13)
            {
                if (Camera.main.transform.position.y + MovePower.y < 28 && Camera.main.transform.position.y + MovePower.y > -4)
                {
                    if (FloatlengthY >= 3 * rate && MovePower == Vector3.up) Camera.main.transform.parent = transform;
                    else if (FloatlengthY <= -3 * rate && MovePower == Vector3.down) Camera.main.transform.parent = transform;
                    else if (IntLengthX == -6 * rate && MovePower == Vector3.left) Camera.main.transform.parent = transform;
                    else if (IntLengthX == 6 * rate && MovePower == Vector3.right) Camera.main.transform.parent = transform;
                    else Camera.main.transform.parent = null;
                }
            }


            //移動
            transform.position += MovePower;
            yield return new WaitForSeconds(0.08f);
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
        //自分と同じ座標のオブジェクトを取得
        GameObject g = Ray();

        if (g.tag == "NotBurning")
        {

            //普通に燃えるオブジェクトがある場合
            if (g.GetComponent<NormalCell>() && !g.GetComponent<Oil>())
            {
                着火できる回数--;
                g.tag = "Burning";
                g.GetComponent<NormalCell>().FireLevel = 10;
                g.GetComponent<NormalCell>().Burning();
            }


        }

    }

    //オイル
    void Oil()
    {
        if (オイルを置ける回数 <= 0) return;

        //自分と同じ座標のオブジェクトを取得
        GameObject g = Ray();


        if (g.gameObject.GetComponent<NormalCell>() && !g.gameObject.GetComponent<Oil>())
        {
            if (g.gameObject.tag == "NotBurning" || g.gameObject.tag == "NowBurn")
            {
                GameObject oil = Instantiate(OilObj, transform);
                oil.transform.parent = GameObject.Find("Grid").transform;
                if (!g.GetComponent<Oil>()) TileMapTest.Num--;
                Destroy(g.gameObject);
                オイルを置ける回数--;
            }
        }
        if (g.gameObject.tag == "Water")
        {
            GameObject oil = Instantiate(OilObj, transform);
            oil.transform.parent = GameObject.Find("Grid").transform;
            //if (!g.GetComponent<Oil>()) TileMapTest.Num--;
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
}
