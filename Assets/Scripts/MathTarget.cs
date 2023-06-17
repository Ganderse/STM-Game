using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MathTarget : MonoBehaviour
{
    [SerializeField] // Add this attribute to make the hud variable visible in the Inspector
    public Animations animate;
    public AudioSource source;
    public AudioClip clip;
    public float health = 50f;
    public GameHud hud;
    //public QuickMathSpawner spawner;
    public bool destroyed = false;
    public bool correct = false;   //Bool to determine if it was the right answer or not
    public string answer;
    private IDictionary<int, int[]> questions = new Dictionary<int, int[]>();


    void Start()
    {

        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
        animate = gameObject.GetComponent<Animations>();
        //spawner = GameObject.Find("Spawner").GetComponent<QuickMathSpawner>();
        QuickMathSpawner spawner = FindObjectOfType<QuickMathSpawner>();
        questions = spawner.QuestionCreator();
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

        // Access the targetAgesAndStates dictionary from the ReflexSpawner script
        ReflexSpawner spawner = FindObjectOfType<ReflexSpawner>();
        spawner.RemoveTargetFromDictionary(gameObject);
        source.PlayOneShot(clip);
        StartCoroutine(animate.fadeout());


    }



}
