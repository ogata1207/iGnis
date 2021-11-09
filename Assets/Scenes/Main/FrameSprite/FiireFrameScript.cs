using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FiireFrameScript : MonoBehaviour {
    public Image fi;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        fi = GetComponent<Image>();
        //Player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (/*Player.GetComponent<Cell>().FireFrame&&*/Player.GetComponent<Cell>().GetFire() > 0 && Input.GetButtonDown("Fire1")) fi.enabled = true;
        else fi.enabled = false;
    }
}
