using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnStatus : MonoBehaviour {

    public int ObjectNumber;
    public int FireLevel;
    void Start()
    {

    }
    public enum Object : int
    {
        NormalTouch = 0,
        BigTouch = 1,
        Oil = 2
    }

}
