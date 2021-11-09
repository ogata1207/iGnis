using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asas : MonoBehaviour {
    AudioSource audioSource;
    public List<AudioClip> audioClip = new List<AudioClip>();
    // Use this for initialization
    void Start () {
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire3"))audioSource.PlayOneShot(audioClip[0]);
    }
}
