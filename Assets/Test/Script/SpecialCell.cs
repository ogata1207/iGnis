using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCell : MonoBehaviour {

    //最大レベル
    static public int MaxLevel = 20;

    public float[] BurnTime;

    //燃え移るの炎のレベル
    public int FireLevel = 0;

    //燃えてるエフェクト
    public GameObject FireEffect;
    public GameObject PulsEffect1;
    //public GameObject PulsEffect2;
    //public GameObject PulsEffect3;
    //public GameObject PulsEffect4;

    //private Vector3 PlusPos1;
    //private Vector3 PlusPos2;
    //private Vector3 PlusPos3;
    //private Vector3 PlusPos4;

    private GameObject Effect;
    public GameObject HitEffect;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    //燃え移るまでの時間
    public int 必要レベル;
    public bool 横の判定 = true;
    public bool 縦の判定 = true;
    public int 燃やしたときに取得できる着火点の数 = 0;
    public int 燃やしたときに取得できるオイルの数 = 0;


    public int 燃えているオブジェクトの数かっこ横かっことじる = 0;
    public int 燃えているオブジェクトの数かっこ縦かっことじる = 0;


    private int 周りの燃えているオブジェクトの数 = 0;
    //public float BurnTime = 0;

    private bool BurnFlg = false;
    private int EffectTimer;
    //ゲームマネージャー
    private GameManager gManager;

    // Use this for initialization
    IEnumerator Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        BurnTime = gManager.NormalBurnTime;
        EffectTimer = 0;
        MaxLevel = BurnTime.Length;
        Effect = null;
        while (周りの燃えているオブジェクトの数 <= 必要レベル - 1)
        {
            //燃え移るまでここをぐーるぐる
            if (!横の判定) 燃えているオブジェクトの数かっこ横かっことじる = 0;
            if (!縦の判定) 燃えているオブジェクトの数かっこ縦かっことじる = 0;
            周りの燃えているオブジェクトの数 = 燃えているオブジェクトの数かっこ横かっことじる + 燃えているオブジェクトの数かっこ縦かっことじる;
            yield return new WaitForSeconds(0.1f);
        }

        //燃え移った
        GameObject.Find("Player").GetComponent<Cell>().AddFire(燃やしたときに取得できる着火点の数);
        GameObject.Find("Player").GetComponent<Cell>().AddOil(燃やしたときに取得できるオイルの数);
        Burn(10);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (BurnFlg) EffectTimer++;

        if (EffectTimer == 1)
        {
            GameObject hoge = Instantiate(HitEffect, transform.position, transform.rotation);
            Destroy(hoge, 0.2f);
            audioSource.PlayOneShot(audioClip[0]);
        }

        if (EffectTimer == 10)
        {
            //PlusPos1 = FireEffect.transform.position;
            //PlusPos1.x = 1.1f;
            GameObject hoge = Instantiate(PulsEffect1, transform.position, transform.rotation);
            Destroy(hoge, 0.15f);
            audioSource.PlayOneShot(audioClip[1]);

        }

    }

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
    public void Burn(int lvl)
    {
        StartCoroutine(burn(lvl));
    }
    
    IEnumerator burn(int level)
    {
        
        tag = "NowBurn";
        BurnFlg = true;
        FireLevel = level - 1 + 5;
        GetComponent<BurnStatus>().FireLevel = FireLevel;
        yield return new WaitForSeconds(BurnTime[FireLevel]);

        tag = "Burning";

        //エフェクト生成
        if (Effect == null)
        {
            Effect = Instantiate(FireEffect, transform);
            Effect.transform.position = transform.position;
        }
        yield return null;
    }



}
