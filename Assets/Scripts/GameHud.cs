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
    //public UnityEngine.UI.Text targetsHitText;

    //Game Variable
    private float targetsHit = 0f;
    public float timeVar = 0.0f;
    public int scoreValue = 0;

    //Text Components
    TextMeshProUGUI targetsHitText;
    TextMeshProUGUI timeText;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update

    private void Start()
    {
        targetsHitText = targets.GetComponent<TextMeshProUGUI>();
        timeText = time.GetComponent<TextMeshProUGUI>();
        scoreText = score.GetComponent<TextMeshProUGUI>();
        UpdateHUD();
    }

    private void Update()
    {
        timeVar += Time.deltaTime;
        UpdateHUD();
    }


    private void UpdateHUD()
    {

        targetsHitText.text = "Targets Hit : " + targetsHit.ToString();
        timeText.text = "Time : " + Math.Truncate(timeVar) + "s";
        scoreText.text = "Score : " + scoreValue.ToString();
        //Debug.Log(targetsHit.ToString());
    }

    public void IncreaseTargetsHit()
    {
        targetsHit++;
        scoreValue += 200;
        UpdateHUD();
    }

    public void DecreaseScore()
    {
        scoreValue -= 100;
        UpdateHUD();
    }

    public void test()
    {
        Debug.Log("test()");
    }



}
