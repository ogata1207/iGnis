using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{

    void Start()
    {
        // 前後左右のオブジェクトを常に探す
        StartCoroutine(CheckObject());
    }


    void Check(GameObject foo)
    {
        if (foo.GetComponent<BurnStatus>() && foo.GetComponent<NormalCell>())
        {
            GetComponent<NormalCell>().hoge(foo.GetComponent<NormalCell>().FireLevel + 2);
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

    IEnumerator CheckObject()
    {
        while (true)
        {
            GameObject foo = Ray(Vector2.up, 0);
            if (foo && foo.tag == "Burning")
            {
                Check(foo);
                //Debug.Log("1");
                break;
            }
            yield return null;
            foo = Ray(Vector2.left, 0);
            if (foo && foo.tag == "Burning")
            {
                Check(foo);
                break;
            }
            yield return null;
            foo = Ray(Vector2.right, 0);
            if (foo && foo.tag == "Burning")
            {
                Check(foo);
                break;
            }
            yield return null;
            foo = Ray(Vector2.down, 0);
            if (foo && foo.tag == "Burning")
            {
                Check(foo);
                break;
            }


            yield return null;
        }
        yield return null;
    }
}
