using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniCon : MonoBehaviour
{
    public int 再生する範囲 = 8;
    private Animator anim;
    private bool flg;
    // Use this for initialization
    IEnumerator Start()
    {
        anim = GetComponent<Animator>();
        while (true)
        {
            Vector2 pos = Camera.main.ViewportToWorldPoint(new Vector2(.5f, .5f));
            float Length = Vector2.Distance(pos, transform.position);
            yield return null;
            if (Length <= 再生する範囲)
                if (flg == false)
                {
                    flg = true;
                    anim.enabled = flg;

                }
                else
                {
                    flg = false;
                    anim.enabled = flg;
                }
           
            yield return null;
        }
        yield return null;
    }


}
