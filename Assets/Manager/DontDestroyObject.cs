using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DontDestroyObject : MonoBehaviour {

    /// <summary>
    /// 擬似Singletonとして使う
    /// Sceneを移動しても保持され続けて
    /// 消されなければ2周目の生成するタイミングで新しいほうを消す
    /// </summary>
    //private static bool inst = false;
    //void Awake()
    //{
    //    if (!inst)
    //    {
    //        DontDestroyOnLoad(this.gameObject);
    //        inst = true;
    //        Debug.Log("Awake: " + this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}



}
