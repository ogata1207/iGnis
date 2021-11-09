using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAudio : MonoBehaviour
{
    AudioSource ads;
    GameManager gManager;

    // Use this for initialization
    void Start()
    {
        ads = GetComponent<AudioSource>();
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gManager.WindDir == Vector2.up) ads.enabled = true;

        else if (gManager.WindDir == Vector2.down) ads.enabled = true;

        else if (gManager.WindDir == Vector2.left)ads.enabled = true;

        else if (gManager.WindDir == Vector2.right)ads.enabled = true;

        else ads.enabled = false;
    }
}
