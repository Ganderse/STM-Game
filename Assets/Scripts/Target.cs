using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    [SerializeField] // Add this attribute to make the hud variable visible in the Inspector
    public Animations animate;
    public AudioSource source;
    public AudioClip clip;
    public float health = 50f;
    public GameHud hud;
    public bool destroyed = false;

    void Start()
    {
        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
        animate = gameObject.GetComponent<Animations>();


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
