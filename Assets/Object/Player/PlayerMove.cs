using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMove : MonoBehaviour
{
    //振動
    public GameObject XInputDotNet;
    private baibu Baibu;

    public float Speed = 1.0f;


    private ShakeCamera shake;

    private int State;

    GameObject HitObj;
    // コ↑コ↓
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    // コ↑コ↓



    // Use this for initialization
    void Start()
    {
       
        shake = GameObject.FindWithTag("MainCamera").GetComponent<ShakeCamera>();
        Baibu = XInputDotNet.GetComponent<baibu>();

        // コ↑コ↓
        audioSource = gameObject.AddComponent<AudioSource>();
        // コ↑コ↓

    }

    // Update is called once per frame
    void Update()
    {

        Time.timeScale = 0.0f;


    }
    void FixedUpdate()
    {
        // プレイヤーの座標を取得
        Vector3 pos = transform.position;

        // 移動方向指定
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        pos.x += (x * Speed);
        pos.y += (y * Speed);

        if (Input.GetButtonDown("Move"))
        {
            if (HitObj != null) Hit(HitObj);
        }
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

        Debug.Log("Hit ->" + HitObj);
    }
    void Hit(GameObject c)
    {
        if (c.transform.tag == "Small")
        {
            if (!c.GetComponent<Small>().SmallFire)
            {
                c.GetComponent<Small>().Hit();
                c.GetComponent<Small>().SmallFire = true;

            }

        }

        // コ↑コ↓
        if (c.transform.tag == "Wall")
        {
            audioSource.PlayOneShot(audioClip[1]);
        }
        // コ↑コ↓
    }



}
