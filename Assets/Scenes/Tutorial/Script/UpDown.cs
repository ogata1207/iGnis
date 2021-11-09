using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour {
    Vector3 Pos;
    // Use this for initialization
    void Start()
    {
        Pos = transform.position;
    }
    //3.7
    // Update is called once per frame
    void Update()
    {

        if (Pos.y < -3.9f) Pos.y += 0.05f;
        else if (Pos.y > -3.7f) Pos.y -= 0.08f;
        transform.position = Pos;
    }

}
