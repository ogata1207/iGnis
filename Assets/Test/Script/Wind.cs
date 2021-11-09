using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public Vector2 Dir;
    public GameObject fire;
    void Start()
    {
        // 前後左右のオブジェクトを常に探す
        //StartCoroutine(CheckObject());
    }


    void Check(GameObject foo)
    {
        if (foo.GetComponent<Wind>())
        {
            foo.GetComponent<Wind>().Burning();
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

    public void Burning()
    {
        tag = "Burning";
        GameObject g = Instantiate(fire, transform);
        g.transform.parent = transform;
        CheckStart();
    }

    public void CheckStart() { StartCoroutine(CheckObject()); }
    IEnumerator CheckObject()
    {
        while (true)
        {
            GameObject f = Ray(Dir, 0);
            if (f && f.tag == "NotBurning")
            {
                Check(f);
                break;
            }
            yield return null;
        }

        GameObject foo;
        if (Vector2.up != Dir * -1)
        {
            foo = Ray(Vector2.up, 0);
            if (foo && foo.tag == "NotBurning")
            {
                if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(10);
                if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ縦かっことじる++;
            }
        }
        if (Vector2.down != Dir * -1)
        {
            foo = Ray(Vector2.down, 0);
            if (foo && foo.tag == "NotBurning")
            {
                if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(10);
                if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ縦かっことじる++;
            }
        }
        if (Vector2.left != Dir * -1)
        {
            foo = Ray(Vector2.left, 0);
            if (foo && foo.tag == "NotBurning")
            {
                if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(10);
                if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ横かっことじる++;
            }
        }
        if (Vector2.right != Dir * -1)
        {
            foo = Ray(Vector2.right, 0);
            if (foo && foo.tag == "NotBurning")
            {
                if (foo.GetComponent<NormalCell>()) foo.GetComponent<NormalCell>().hoge(10);
                if (foo.GetComponent<SpecialCell>()) foo.GetComponent<SpecialCell>().燃えているオブジェクトの数かっこ横かっことじる++;

            }
        }
        yield return null;
    }
}
