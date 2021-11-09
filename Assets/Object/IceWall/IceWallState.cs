using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class IceWallState : MonoBehaviour {
    GameObject TemperatureCheck;    // 温度計
    public float IceBreakCount;
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    // Use this for initialization
    void Start () {
        TemperatureCheck = GameObject.Find("Slider");
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (TemperatureCheck.GetComponent<Temperature>().TemperatureNum >= IceBreakCount)
        {
            audioSource.PlayOneShot(audioClip[0]);
            LogManager.AddLog(this.name + "が溶けたｱｱｱｱｧｧｧｱ!!♂");
            Destroy(gameObject);
        }
        //Debug.Log(TemperatureCheck.GetComponent<Temperature>().TemperatureNum);
	}
}
