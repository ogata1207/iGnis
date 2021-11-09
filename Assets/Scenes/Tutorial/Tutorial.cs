using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    [SerializeField]
    Fade fade = null;
    public GameObject tex;
    int ChangeTimer;
    bool ChangeF;
    int a;
    GameObject Devil;
    void Start()
    {
        fade.FadeIn(0.0f, () =>
        {
            fade.FadeOut(1);
        });
        ChangeTimer = 0;
        ChangeF = false;
        Devil = GameObject.Find("Devil");
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Tutorial");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            fade.FadeIn(2);
            ChangeF = true;
        }
        if (tex == null) a++;
        if (/*Input.GetKeyDown(KeyCode.Return) && tex.EndFlg*/a == 1)
        {
            fade.FadeIn(2);
            ChangeF = true;
        }
        if (ChangeF) ChangeTimer++;
        if (ChangeTimer > 60 * 2)
        {
            SceneManager.LoadScene("Check");
            //ChangeTimer = 0;
        }
        if (tex == null) Destroy(Devil);

    }
}
