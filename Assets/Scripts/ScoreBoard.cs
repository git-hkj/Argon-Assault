using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score =0;
    TMP_Text scoreText;
   
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Welcome";
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    //To keep track of the score
    public void ScoreUpdate(int scoreInc)
    {
        score += scoreInc;
        Debug.Log($"Current Score:{score}");
        scoreText.text = "Score:";
        scoreText.text += score.ToString();
    }
}
