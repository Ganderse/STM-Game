using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class GameHud : MonoBehaviour
{  
    //UI Text GameObjects
    public GameObject targets;
    public GameObject time;
    public GameObject score;
    public GameObject difficulty;
    //public UnityEngine.UI.Text targetsHitText;

    //Game Variable
    private float targetsHit = 0f;
    public float timeVar = 0.0f;
    public float scoreValue = 0;
    public float diffValue = 0.0f;
    //Text Components
    TextMeshProUGUI targetsHitText;
    TextMeshProUGUI timeText;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI difficultyText;

    //public ScoresMenu scoreboard;


    // Start is called before the first frame update

    private void Start()
    {
        //scoreboard = GameObject.Find("Canvas").GetComponent<ScoresMenu>();

        targetsHitText = targets.GetComponent<TextMeshProUGUI>();
        timeText = time.GetComponent<TextMeshProUGUI>();
        scoreText = score.GetComponent<TextMeshProUGUI>();
        difficultyText = difficulty.GetComponent<TextMeshProUGUI>();
        UpdateHUD();
    }

    private void Update()
    {
        timeVar += Time.deltaTime;
        UpdateHUD();

        //TIMER
        if (timeVar >= 25f)
        {
            SceneManager.UnloadScene(1);

            SceneManager.LoadScene(2);
        }
        
    }


    private void UpdateHUD()
    {

        targetsHitText.text = "Targets Hit : " + targetsHit.ToString();
        timeText.text = "Time : " + Math.Truncate(timeVar) + "s";
        scoreText.text = "Score : " + Math.Truncate(scoreValue).ToString();
        difficultyText.text = "Difficulty : " + diffValue.ToString();
        //Debug.Log(targetsHit.ToString());
    }

    public void IncreaseTargetsHit()
    {
        targetsHit++;
        UpdateHUD();
    }

    public void UpdateDifficulty(float updatedDiff)
    {
        diffValue = 10/updatedDiff; //The higher the value, the higher difficulty
        UpdateHUD();
    }

    public void UpdateScore(float scoreAmount)
    {
        scoreValue += scoreAmount;
        UpdateHUD();
    }

    public void test()
    {
        Debug.Log("test()");
    }



}
