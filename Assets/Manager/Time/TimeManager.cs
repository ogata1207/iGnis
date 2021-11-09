using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour {

    static public float time = 60;
    static public bool Activate = true;

    public GameManager gManager;
    public Text DrawTimeRender;

	// Use this for initialization
	IEnumerator Start ()
    {
        if (gManager) time = gManager.ゲーム時間;
        while (time > 0)
        {
            time -= ( 1 * Time.deltaTime ) * Time.timeScale;
            if (time <= 0) time = 0;
            if (DrawTimeRender) DrawTimeRender.text = "" + time.ToString("f3");
            yield return null;
        }
        time = 0;
        yield return null;
	}
	


}
