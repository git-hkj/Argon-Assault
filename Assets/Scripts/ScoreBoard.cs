using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score =0;

    //To keep track of the score
    public void ScoreUpdate(int scoreInc)
    {
        score += scoreInc;
        Debug.Log($"Current Score:{score}");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
