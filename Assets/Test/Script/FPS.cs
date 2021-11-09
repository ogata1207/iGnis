using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FPS : MonoBehaviour {

    public Text text;
    public Text 占有率;
    private GameManager gManager;
	// Update is called once per frame
	IEnumerator Start ()
    {
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        while (true)
        {
            //text.text = "FPS:" + (int)(1f / Time.deltaTime);
            text.text = "残り :" + TileMapTest.Num+"マス";

            //占有率.text = "占有率: " + gManager.Occupancy + "%";
            yield return new WaitForSeconds(0);
        }
    }
    void Update()
    {
        占有率.text = "占有率: " + gManager.Occupancy.ToString("f2") + "%";
    }
}
