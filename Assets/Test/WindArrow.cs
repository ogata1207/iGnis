using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArrow : MonoBehaviour {
    public float speed = 0.1F;
    GameManager gManager;
    // Use this for initialization
    void Start () {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {

        var vec = ((transform.position+(Vector3)gManager.WindDir) - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);

    }
}
