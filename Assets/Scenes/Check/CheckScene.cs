using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckScene : MonoBehaviour {
    [SerializeField]
    Fade fade = null;
    bool ChangeF;
    bool aa;
    bool bb;
    int aat;
    int bbt;
    int TutoTimer;
    int MainTimer;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        fade.FadeIn(0.0f, () =>
        {
            fade.FadeOut(1);
        });
        aat = 0;
        bbt = 0;
        ChangeF = false;
        TutoTimer = 0;
        MainTimer = 0;
        aa = false;
        bb = false;
    }
    void Update()
    {

        // メイン
        {
            if (Input.GetButtonDown("Fire3"))
            {
                audioSource.PlayOneShot(audioClip[0]);
                MainTimer++;
            }
            if (MainTimer == 1)
            {
                fade.FadeIn(2);
                aa = true;
            }
            if (aa) aat++;
            if (aat > 60 * 2)
            {
                SceneManager.LoadScene("Main");
            }
        }

        // 徳井(チュートリアル)
        // リセマラ30分で終わったwwwww
        {
            if (Input.GetButtonDown("Fire2"))
            {
                audioSource.PlayOneShot(audioClip[0]);
                TutoTimer++;
            }
            if (TutoTimer == 1)
            {
                fade.FadeIn(2);
                ChangeF = true;
            }
            if (ChangeF) bbt++;
            if (bbt > 60 * 2)
            {
                SceneManager.LoadScene("Tutorial");
            }
        }
    }
}
