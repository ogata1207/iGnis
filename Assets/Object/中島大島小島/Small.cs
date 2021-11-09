using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 小島
public class Small : MonoBehaviour
{
    AudioSource audioSource;  // ここコピペ
    public List<AudioClip> audioClip = new List<AudioClip>();  // ここコピペ

    public bool SmallFire;
    float changeRed = 1.0f;
    float changeGreen = 1.0f;
    float changeBlue = 1.0f;
    float chageAlpha = 1.0f;

    public GameObject FireEffect;
    public GameObject Fire;
    public GameObject PlusEffect;
    public GameObject IrandFireEffect;


    private CircleCollider2D Cc2d;


    float HitStop;
    public bool CameraZoom;

    bool PlayerHit;
    bool MyHit;

    int Timer;
    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // ここコピペ
        SmallFire = false;
        Cc2d = GetComponent<CircleCollider2D>();
        CameraZoom = false;
        HitStop = 0;
        PlayerHit = false;
        MyHit = false;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SmallFire)
        {
            Timer++;
            changeGreen = 0.0f;
            changeBlue = 0.0f;
        }
        if(Timer>= 30)
        {
            Cc2d.radius = 4.0f;
        }
        if (Time.timeScale <= 0.0f)
        {
            HitStop++;
            CameraZoom = true;
        }
        else HitStop = 0;
        if (HitStop > 8) CameraZoom = false;
        if (HitStop > 10)
        {
            Time.timeScale = 1.0f;
            HitStop = 0;
        }
        this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, changeBlue, chageAlpha);
    }


    public void Hit()
    {
            Time.timeScale = 0.0f;

            GameObject ef = Instantiate(PlusEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(ef, 0.37f);
            GameObject ef5 = Instantiate(IrandFireEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(ef5, 0.3f);
            GameObject ef2 = Instantiate(FireEffect, transform.position, Quaternion.identity) as GameObject;
            GameObject ef3 = Instantiate(Fire, transform.position, Quaternion.identity) as GameObject;
            audioSource.PlayOneShot(audioClip[0]);  // ここコピペ

            PlayerHit = true;
            //2018/05/14 編集(OGT)
            //SmallFire = true;
            // 2018/05/10 00:37 追加(OGT)
            LogManager.AddLog(this.name + "が燃えました");
        }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Small" && !SmallFire && !PlayerHit)
        {
            Time.timeScale = 0.5f;
            GameObject ef = Instantiate(PlusEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(ef, 0.37f);
            GameObject ef5 = Instantiate(IrandFireEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(ef5, 0.3f);
            GameObject ef2 = Instantiate(FireEffect, transform.position, Quaternion.identity) as GameObject;
            GameObject ef3 = Instantiate(Fire, transform.position, Quaternion.identity) as GameObject;
            audioSource.PlayOneShot(audioClip[0]);  // ここコピペ

            MyHit = true;
            SmallFire = true;
            //2018/05/14 編集(OGT)
            //SmallFire = true;
            // 2018/05/10 00:37 追加(OGT)
            LogManager.AddLog(this.name + "が燃えました");
        }

    }
}
