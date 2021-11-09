using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFont : MonoBehaviour {
    public GameObject ClearObj;
    private SpriteRenderer Sp;
    private Animator an;

    // Use this for initialization
    void Start () {
        Sp = GetComponent<SpriteRenderer>();
        an = GetComponent<Animator>();
        Sp.enabled = false;
        an.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (TileMapTest.Num <= 0)
        {
            Sp.enabled = true;
            an.enabled = true;
            Destroy(gameObject, 3.0f);
        }

    }
}
