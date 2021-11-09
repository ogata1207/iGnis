using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour {
    public Color FireModeColor = Color.red;
    public Color OilModeColor = Color.magenta;
    private SpriteRenderer sprite;
    public GameObject Player;

    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1")) sprite.color = FireModeColor;
        if (Input.GetButtonDown("Fire2")&&Player.GetComponent<Cell>().OilOk) sprite.color = OilModeColor;
    }
}
