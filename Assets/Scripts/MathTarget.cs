using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static QuickMathSpawner;
using TMPro;


public class MathTarget : MonoBehaviour
{
    [SerializeField] // Add this attribute to make the hud variable visible in the Inspector
    public Animations animate;
    public AudioSource source;
    public AudioClip clip;
    public float health = 50f;
    public GameHud hud;
    private QuickMathSpawner spawner;
    //public QuickMathSpawner spawner;
    public bool destroyed = false;
    public bool issCorrect = false;   //Bool to determine if it was the right answer or not

//Game Variable

    public int givenAnswer;
    //private IDictionary<int, int[]> questions = new Dictionary<int, int[]>();

    //public GameObject targetAnswer;

    
    //Text Components
    public TMP_Text targetAnswerText;
    // to put the text on the screen do : targetAnswerText.text;



    void Start()
    {
        QuickMathSpawner.Operation targetQuestion = new QuickMathSpawner.Operation { };
        System.Random rnd = new System.Random();
        //targetAnswerText = targetAnswer.GetComponentInChildren<TextMeshProUGUI>();


        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
        animate = gameObject.GetComponent<Animations>();
        //spawner = GameObject.Find("Spawner").GetComponent<QuickMathSpawner>();
        spawner = FindObjectOfType<QuickMathSpawner>();

        //questions = spawner.QuestionsAndAnswers;

        //questions = spawner.QuestionCreator();

        //if (spawner.QuestionsAndAnswers.Count > 0)
        //{
            int questionIndex = rnd.Next(0, spawner.QuestionsAndAnswers.Count);
            targetQuestion = spawner.QuestionsAndAnswers[questionIndex];
            spawner.QuestionDelete(questionIndex);
        //} else
        //{
        //    Debug.Log("No more questions in list");
        //}

        givenAnswer = targetQuestion.AnswerCandidate;
        issCorrect = targetQuestion.isCorrect;
//        Debug.Log("My current answer is:" + givenAnswer);

        targetAnswerText.text = givenAnswer.ToString();

    }
    /*
    private void Update()
    {
    }*/




    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    public bool IsDestroyed()
    {
        return destroyed;
    }



    //User has shot the target
    void Die()
    {
        hud.IncreaseTargetsHit();

        //Debug.Log(hud.timeVar);
        destroyed = true;

        

        // Access the targetAgesAndStates dictionary from the QuickMathSpawner script
        QuickMathSpawner spawner = FindObjectOfType<QuickMathSpawner>();


        //Change the difficulty depending on answer
        if (issCorrect)
        {
            spawner.ChangeDifficulty(1.0f);
        } else
        {
            spawner.ChangeDifficulty(-1.0f);
        }

        //Removing current object from Dictionary with all the targets
        spawner.RemoveTargetFromDictionary(gameObject);

        //Destroys the current game object
        Destroy(gameObject);

        //Destroys all the other targets
        spawner.DestroyAllTargets();

        //Plays the shooting sound effect
        source.PlayOneShot(clip);

        //StartCoroutine(animate.fadeout());


    }



}
