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
    public GameObject question;
    public GameObject MathDifficulty;
    public GameObject MathLevel;
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
    public float MathDiff;
    public int MathLevelValue;
    public string quesiton { get; set; }
    //Text Components
    TextMeshProUGUI targetsHitText;
    TextMeshProUGUI timeText;
    TextMeshProUGUI scoreText;
    TextMeshProUGUI difficultyText;
    TextMeshProUGUI questionText;
    TextMeshProUGUI mathLevelText;
    TextMeshProUGUI mathDifficultyText;

    // Start is called before the first frame update

    private void Start()
    {
        targetsHitText = targets.GetComponent<TextMeshProUGUI>();
        timeText = time.GetComponent<TextMeshProUGUI>();
        scoreText = score.GetComponent<TextMeshProUGUI>();
        difficultyText = difficulty.GetComponent<TextMeshProUGUI>();
        questionText = question.GetComponent<TextMeshProUGUI>();
        mathDifficultyText = MathDifficulty.GetComponent<TextMeshProUGUI>();
        mathLevelText = MathLevel.GetComponent<TextMeshProUGUI>(); 
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
        questionText.text = quesiton;
        targetsHitText.text = targetsHit.ToString() + "/" + totalHit.ToString();
        timeText.text = fTime;// "Time : " + Math.Truncate(timeVar) + "s";
        scoreText.text = "Score : " + Math.Truncate(scoreValue).ToString();

        if (diffValue >= 1)
        {
            difficultyText.text = "Difficulty : " + Mathf.RoundToInt(diffValue).ToString();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            mathDifficultyText.text = "Difficulty : " + Mathf.RoundToInt(MathDiff).ToString();
            mathLevelText.text = "Level : " + MathLevelValue.ToString();
        }

        
        //Debug.Log(targetsHit.ToString());
    }


    public void IncreaseTargetsHit()
    {
        targetsHit++;
        UpdateHUD();
    }

    public void UpdateMathDifficulty(float updatedDiff)
    {
        MathDiff = updatedDiff;
        UpdateHUD();
    }

    public void UpdateLevel(int updatedLevel)
    {
        MathLevelValue = updatedLevel;
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
