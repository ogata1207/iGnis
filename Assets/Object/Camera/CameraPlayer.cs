using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {
    GameObject Player;
    Vector3 Pos;
	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        Pos = transform.position;
      
	}
	
	// Update is called once per frame
	void Update () {
            Pos.x = Player.transform.position.x;
            Pos.y = Player.transform.position.y;
            transform.position = Pos;
    }
}
