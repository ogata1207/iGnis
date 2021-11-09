using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    // 変化量
    public float dx;

    void Update()
    {
        // dxは任意の値
        this.transform.position += new Vector3(0, dx * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            dx += 10.0f;
        }
    }
}
