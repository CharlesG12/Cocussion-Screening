using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ResultsScript : MonoBehaviour{

    public Text timeElapsed;
    public Text IncorrectView;

    void Start(){
        Results.Init();
        Results.SetScore("scene2", "time", "190");

        timeElapsed.text = Results.GetScore("scene1", "time");
        IncorrectView.text = Results.GetScore("scene2", "time");
     }

    void Update()
    {
      
    }
}
