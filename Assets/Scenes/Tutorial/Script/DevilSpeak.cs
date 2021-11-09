using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilSpeak : MonoBehaviour
{
    int Wait;
    // Use this for initialization
    void Start()
    {
        Wait = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && FindObjectOfType<TextWindow>().NextText/* && FindObjectOfType<TextWindow>().Stop == 0*/)
        {
            Wait = 0;
            GetComponent<Animator>().SetTrigger("Speak");
        }
        else if (Wait >= 90)
        {
            GetComponent<Animator>().SetTrigger("Eye");
            Wait = 0;
        }
        else
        {
            GetComponent<Animator>().SetTrigger("No");
            Wait++;
        }


    }
}
