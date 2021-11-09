using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public Scene scene;
    private string SceneName;
    public int タイトルシーン番号 = 0;
    public int リザルトシーン番号 = 0;
    public int 追加予定;
    private static bool inst = false;

    void Awake()
    {
        if (!inst)
        {
            DontDestroyOnLoad(this.gameObject);
            inst = true;
            Debug.Log("Awake: " + this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        SceneName = scene.name;
        LogManager.Init();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.M))SceneManager.LoadScene(リザルトシーン番号);
        if (Input.GetKeyDown(KeyCode.N)) SceneManager.LoadScene(タイトルシーン番号);
       
	}
}
