using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static QuickMathSpawner;

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
    private int givenAnswer;
    //private IDictionary<int, int[]> questions = new Dictionary<int, int[]>();


    void Start()
    {
        QuickMathSpawner.Operation targetQuestion = new QuickMathSpawner.Operation { };
        System.Random rnd = new System.Random();


        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
        animate = gameObject.GetComponent<Animations>();
        //spawner = GameObject.Find("Spawner").GetComponent<QuickMathSpawner>();
        spawner = FindObjectOfType<QuickMathSpawner>();

        //questions = spawner.QuestionsAndAnswers;

        //questions = spawner.QuestionCreator();

        if (spawner.QuestionsAndAnswers.Count > 0)
        {
            int questionIndex = rnd.Next(0, spawner.QuestionsAndAnswers.Count);
            targetQuestion = spawner.QuestionsAndAnswers[questionIndex];
            spawner.QuestionDelete(questionIndex);
        } else
        {
            Debug.Log("No more questions in list");
        }

        givenAnswer = targetQuestion.AnswerCandidate;
        issCorrect = targetQuestion.isCorrect;
    }




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
        spawner.RemoveTargetFromDictionary(gameObject);
        Debug.Log("Dying, next line destroys all targets");
        Destroy(gameObject);
        spawner.DestroyAllTargets();
        source.PlayOneShot(clip);

        //StartCoroutine(animate.fadeout());


    }



}
