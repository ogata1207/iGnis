using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{

    //配置するオブジェクト
    public GameObject obj;

    //飛ばす方向
    public Vector2 方向 = Vector2.zero;

    //飛ばす距離
    public int Length = 1;

    //いつもの
    public void SetDir(Vector2 d) { 方向 = d; }
    // Use this for initialization
    void Start()
    {
        //もし飛ばす方向が決められていなければとりあえず右向きに発射する
        if (方向 == Vector2.zero) 方向 = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        //ﾃﾞﾊﾞｯｸﾞ用
        if (Input.GetKeyDown(KeyCode.P)) StartCoroutine(Search(方向));
    }

    IEnumerator Search(Vector2 dir)
    {
        GameObject foo;

        //指定された方向にあるオブジェクトを取得して
        //特定のオブジェクトがあった場合そこにオイルを置く
        for (int i = 1; i <= Length; i++)
        {
            foo = Ray(dir * i, 0);

            //普通に燃えるマス(旧:NormalTorch)
            if (!foo.gameObject.GetComponent<Oil>() && foo.gameObject.GetComponent<NormalCell>())
            {
                if (foo.gameObject.tag == "NotBurning")
                {
                    GameObject wind = Instantiate(obj, transform);
                    wind.transform.position = transform.position + (Vector3)(dir * i) + new Vector3(0, 0, -2);
                    wind.GetComponent<Wind>().Dir = dir;
                    wind.GetComponent<SpriteRenderer>().sortingOrder = -2;
                    TileMapTest.Num--;
                    Destroy(foo.gameObject);
                }
                yield return null;
            }   //水(Colだけのオブジェクト)
            else if (foo.gameObject.tag == "Water")
            {
                GameObject wind = Instantiate(obj, transform);
                wind.transform.position = transform.position + (Vector3)(方向 * i) + new Vector3( 0, 0, -2 );
                wind.GetComponent<Wind>().Dir = dir;
                wind.GetComponent<SpriteRenderer>().sortingOrder = -2;
                Destroy(foo.gameObject);

                yield return null;
            }
        }

        //自分から1マス先にあるオイルに火をつける
        //foo = Ray(dir, 0);
        //if (foo.gameObject.GetComponent<Oil>())
        //{
        //    foo.gameObject.tag = "Burning";
        //    foo.gameObject.GetComponent<NormalCell>().FireLevel = 0;
        //    foo.gameObject.GetComponent<NormalCell>().hoge(0);
        //}
        yield return null;
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
