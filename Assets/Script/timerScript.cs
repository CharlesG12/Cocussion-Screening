using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timerScript : MonoBehaviour {

    private string levelToLoad = "Scene2";
    private float timer = 10f;
    private Text timerSec;

	// Use this for initialization
	void Start () {
        timerSec = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        timerSec.text = timer.ToString("f2");
        if(timer <= 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }
	}
}
