using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScloorLR : MonoBehaviour {

    public float speed = 10;
    public int spriteCount = 2;
    GameManager gManager;
    SpriteRenderer sp;
    private Vector3 pos;
    void Start()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sp = GetComponent<SpriteRenderer>();
        pos = transform.position;
    }
    void FixedUpdate()
    {
        if (gManager.WindDir == Vector2.left)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            sp.enabled = true;
        }
        else
        {
            transform.position = pos;
            sp.enabled = false;
        }
    }

    void OnBecameInvisible()
    {
        if (gManager.WindDir == Vector2.left)
        {
            float width = GetComponent<SpriteRenderer>().bounds.size.x;
            transform.position += Vector3.right * width * spriteCount;
        }

    }
}
