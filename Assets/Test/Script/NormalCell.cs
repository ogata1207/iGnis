using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCell : MonoBehaviour
{
    public GameObject Particle;
    //最大レベル
    static public int MaxLevel = 20;
    private GameManager gManager;
    private float[] BurnTime;

    //燃え移るの炎のレベル
    public int FireLevel = 0;
    private bool[] BurnFlg;
    private int BurnCount = 0;
    private Vector2 SaveDir = Vector2.zero;
    public GameObject HitEffect;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    // Use this for initialization
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        BurnTime = gManager.NormalBurnTime;
        MaxLevel = BurnTime.Length;
        BurnFlg = new bool[4];
        for (int i = 0; i < 4; i++) BurnFlg[i] = false;
        audioSource = gameObject.AddComponent<AudioSource>();
        //if (!GetComponent<Oil>()) TileMapTest.num++;
        //StartCoroutine(updt());
    }

    IEnumerator burn(int level)
    {
        tag = "NowBurn";
        FireLevel = level - 1;
        if (FireLevel <= 0) FireLevel = 1;
        if (FireLevel >= 19) FireLevel = 19;
        if (GetComponent<Oil>()) FireLevel = 0;
        yield return new WaitForSeconds(BurnTime[FireLevel]);

        if (FireLevel >= 0)
        {
            StartCoroutine(HitCheck());

        }
        tag = "Burning";
        yield return null;
    }
    public void Burning()
    {
        GameObject g = Instantiate(Particle, transform);
        g.transform.parent = transform;
        GetComponent<BurnStatus>().FireLevel = FireLevel;

        //TileMapTest.FireNum++;
        //TileMapTest.Num--;
        StartCoroutine(HitCheck());

    }
    public void Burning(int lvl)
    {
        tag = "Burning";
        GameObject g = Instantiate(Particle, transform);
        g.transform.parent = transform;
        GetComponent<BurnStatus>().FireLevel = lvl;
        //TileMapTest.FireNum++;
        //TileMapTest.Num--;
        StartCoroutine(HitCheck());

    }
    public void hoge(int lvl)
    {
        StartCoroutine(burn(lvl));
    }

    public void Check()
    {
        StartCoroutine(HitCheck());
    }

    IEnumerator HitCheck()
    {
        TileMapTest.FireNum++;
        /*if (!GetComponent<Oil>()) */TileMapTest.Num--;
        GameObject g = Instantiate(Particle, transform);
        g.transform.parent = transform;
        GetComponent<BurnStatus>().FireLevel = FireLevel;

        GameObject hoge = Instantiate(HitEffect, g.transform.position, transform.rotation);
        Destroy(hoge, 0.2f);
        audioSource.PlayOneShot(audioClip[0]);

        yield return new WaitForSeconds(0.5f);
        GameObject foo;
        while (true)
        {
            //ベクトルが { 0, 0 } なら　全方向
            if (gManager.WindDir == Vector2.zero)
            {
                BurnCount = 0;
                if (BurnFlg[0] != true)
                {
                    foo = Ray(Vector2.up, 0);
                    if (foo && foo.tag == "NotBurning")
                    {
                        if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(FireLevel);
                        if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ縦かっことじる++;
                        if (foo.GetComponent<Wind>()) foo.GetComponent<Wind>().Burning();
                        //GameObject hoge = Instantiate(HitEffect, transform.position, transform.rotation);
                        //Destroy(hoge, 0.2f);
                        //audioSource.PlayOneShot(audioClip[0]);
                        BurnFlg[0] = true;
                    }
                }
                else { BurnCount++; }
                yield return null;
                if (BurnFlg[1] != true)
                {
                    foo = Ray(Vector2.down, 0);
                    if (foo && foo.tag == "NotBurning")
                    {
                        if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(FireLevel);
                        if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ縦かっことじる++;
                        if (foo.GetComponent<Wind>()) foo.GetComponent<Wind>().Burning();
                        //GameObject hoge = Instantiate(HitEffect, transform.position, transform.rotation);
                        //Destroy(hoge, 0.2f);
                        //audioSource.PlayOneShot(audioClip[0]);
                        BurnFlg[1] = true;
                    }
                }
                else { BurnCount++; }
                yield return null;
                if (BurnFlg[2] != true)
                {
                    foo = Ray(Vector2.left, 0);
                    if (foo && foo.tag == "NotBurning")
                    {
                        if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(FireLevel);
                        if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ横かっことじる++;
                        if (foo.GetComponent<Wind>()) foo.GetComponent<Wind>().Burning();
                        //GameObject hoge = Instantiate(HitEffect, transform.position, transform.rotation);
                        //Destroy(hoge, 0.2f);
                        //audioSource.PlayOneShot(audioClip[0]);
                        BurnFlg[2] = true;
                    }
                }
                else { BurnCount++; }
                yield return null;
                if (BurnFlg[3] != true)
                {
                    foo = Ray(Vector2.right, 0);
                    if (foo && foo.tag == "NotBurning")
                    {
                        if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(FireLevel);
                        if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ横かっことじる++;
                        if (foo.GetComponent<Wind>()) foo.GetComponent<Wind>().Burning();
                        //GameObject hoge = Instantiate(HitEffect, transform.position, transform.rotation);
                        //Destroy(hoge, 0.2f);
                        //audioSource.PlayOneShot(audioClip[0]);
                        BurnFlg[3] = true;
                    }
                }
                else { BurnCount++; }
                if (BurnCount >= 4) break;
                yield return null;

            }
            //方向指定
            else
            {

                yield return new WaitForSeconds(1f);
                Debug.Log("ほえええええ");
                for (int i = 1; i <= gManager.風で燃え移るマスの長さ; i++)
                {
                    foo = Ray(gManager.WindDir * i, 0);
                    if (!foo) continue;
                    else if (foo.tag == "Water") break;
                    else if (foo && foo.tag == "NotBurning")
                    {
                        if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().Burning(10);
                        if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ縦かっことじる++;
                        if (foo.GetComponent<Wind>()) foo.GetComponent<Wind>().Burning();
                        //GameObject hoge = Instantiate(HitEffect, transform.position, transform.rotation);
                        //Destroy(hoge, 0.2f);
                        //yield return new WaitForSeconds(0.2f);
                    }

                }
            }
            yield return null;
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

}
