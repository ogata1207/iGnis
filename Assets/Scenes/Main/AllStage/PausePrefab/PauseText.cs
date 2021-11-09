using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseText : MonoBehaviour {

    private Vector2 SavePos;
    private Vector2 MovePos;

    public Vector2 MovePower = new Vector2( -3.0f, 0 );
    public float Speed = 1.0f;

    public bool flg = false;
	// Use this for initialization
	void Start () {
        SavePos = (Vector2)transform.position;
        MovePos = (Vector2)transform.position + MovePower;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N)) MoveText();
        if (Input.GetKeyDown(KeyCode.B)) flg = true;
	}
    public void MoveText()
    {
        StartCoroutine(Move());
    }
    public void BackText()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        float foo = 0;
        var speed = Speed / 100;
        flg = false;
        
        while (true)
        {
            if (foo >= 1.0f) break;
            foo += speed;
            transform.position = Vector2.Lerp((Vector2)transform.position, MovePos, foo);

            yield return null;
        }
        while(flg != true) { yield return null; }

        foo = 0;
        Vector2 pos = (Vector2)transform.position;

        while (true)
        {
            if (foo >= 1.0f) break;
            foo += speed;
            transform.position = Vector2.Lerp(pos, SavePos, foo);

            yield return null;
        }
        yield return null;
    }
}
