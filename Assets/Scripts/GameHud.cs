using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

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
    private float totalHit = 0f;
    public float timeVar = 0.0f;
    public int minutes = 0;
    public int seconds = 0;
    public string fTime = "";
    public float scoreValue = 0;
    public float diffValue = 0.0f;
    //Text Components
    TextMeshProUGUI targetsHitText;
    TextMeshProUGUI timeText;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI difficultyText;

    // Start is called before the first frame update

    private void Start()
    {
        targetsHitText = targets.GetComponent<TextMeshProUGUI>();
        timeText = time.GetComponent<TextMeshProUGUI>();
        scoreText = score.GetComponent<TextMeshProUGUI>();
        difficultyText = difficulty.GetComponent<TextMeshProUGUI>();
        UpdateHUD();
    }

    private void Update()
    {
        timeVar += Time.deltaTime;
        minutes = Mathf.FloorToInt(timeVar / 60F);
        seconds = Mathf.FloorToInt(timeVar - minutes * 60);
        fTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        UpdateHUD();
    }


    private void UpdateHUD()
    {

        targetsHitText.text = targetsHit.ToString() + "/" + totalHit.ToString();
        timeText.text = fTime;// "Time : " + Math.Truncate(timeVar) + "s";
        scoreText.text = "Score : " + Math.Truncate(scoreValue).ToString();
        difficultyText.text = "Difficulty : " + Mathf.RoundToInt(diffValue).ToString();
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

    public void UpdateTotalHit()
    {
        totalHit++;
        UpdateHUD();
    }



}
