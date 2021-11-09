using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiri : MonoBehaviour
{
    public Vector3 StartPos;
    public GameObject BG;
    public int x;
    public int end;
    public float Speed;

    // Use this for initialization
    IEnumerator Start()
    {
        
        while (transform.position.x >= x) yield return null;

 
        GameObject obj = Instantiate(BG);
        obj.transform.parent = GameObject.Find("BG").transform;

        // スプライトの横幅
        float w = GetComponent<SpriteRenderer>().bounds.size.x;
        obj.transform.position = transform.position;
        obj.transform.position += new Vector3(w, 0, 0);

        while (transform.position.x >= end) yield return null;

        Destroy(gameObject);
        yield return null;
    }

    void Update()
    {
        transform.position += new Vector3(-Speed, 0);
    }
}
