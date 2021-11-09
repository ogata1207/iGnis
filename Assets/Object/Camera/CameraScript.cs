using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


    //public float Speed = 1.0f;
    public GameObject player;
    public float Size1 = 5;
    public float Size2 = 10;
    private int State = 1;
 
    // Use this for initialization
    void Start ()
    { 

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
        if (/*Input.GetKeyDown(KeyCode.Z)*/Input.GetButtonDown("CameraZoom"))
        {
            switch (State)
            {
                case 0:     //None
                    break;
                case 1:     //通常カメラ
                    StartCoroutine(Zoom(Size1, Size2, 5.0f ));
                    break;
                case 2:     //視野が広いカメラ
                    StartCoroutine(Zoom( Size2, Size1, 5.0f));
                    StartCoroutine(PositionCorrection(player.transform.position, 5.0f));
                    break;
            }
        }

    }

    // Speed :  1 = 0.01f
    IEnumerator Zoom( float Start , float End, float Speed )
    {
        var SaveState = State;
        State = 0;

        float foo = 0;
        var speed = Speed / 100;
        while (true)
        {
            if (foo >= 1.0f) break;
            foo += speed;
            Camera.main.orthographicSize = Mathf.Lerp(Start, End, foo);
            
            yield return null;
        }
        if (SaveState == 1) State = 2;
        else State = 1;

        yield return null;
    }

    IEnumerator PositionCorrection(Vector2 target, float Speed)
    {
        var SaveState = State;

        Vector3 Start = transform.position;
        float foo = 0;
        var speed = Speed / 100;
        while (true)
        {
            if (foo >= 1.0f) break;
            foo += speed;
            //Camera.main.orthographicSize = Mathf.Lerp(Start, End, foo);
            transform.position = Vector2.Lerp(Start, target, foo);

            yield return null;
        }


        yield return null;
    }


}
