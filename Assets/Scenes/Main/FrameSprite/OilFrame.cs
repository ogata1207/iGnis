using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilFrame : MonoBehaviour {
    public Image OilFrameImage;
    public GameObject Player;
    private int OilSetWait;
    // Use this for initialization
    void Start () {
        OilFrameImage = GetComponent<Image>();
       // Player = GameObject.Find("Player");
        OilSetWait = 0;
    }

    // Update is called once per frame
    void Update () {
        if(Input.GetButton("Fire2"))
        {
            OilSetWait++;
        }
        if (Player.GetComponent<Cell>().OilOk&&Player.GetComponent<Cell>().GetOil() > 0 && OilSetWait > 5)
        {
            OilSetWait++;
            OilFrameImage.enabled = true;
            OilSetWait = 0;
        }
        else OilFrameImage.enabled = false;
    }
}
