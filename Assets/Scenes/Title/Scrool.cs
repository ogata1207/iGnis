using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]

public class Scrool : MonoBehaviour {

    public float speed = 10;
    public int spriteCount = 2;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        float hight = GetComponent<SpriteRenderer>().bounds.size.y;
        transform.position += Vector3.up * hight * spriteCount;
    }
}
