using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
        The difficulty will change like this :

        Succesful target hit -> Score + 20 + (Multiplier * 20)

        Multiplier -> (Difficulty) * (Time between shots) / 10

        Time between target shots ->  Total time = Difficulty/2

                                   if Time between target spawn and hit < difficulty / 4 --> difficulty - difficulty*0.1
                                   if Time between target spawn and hit < 3 * difficulty / 4 --> difficulty + difficulty*0.1

        Missed shots -> Score - 10
        */



public class ReflexSpawner : MonoBehaviour
{
    public float timer = 0.0f; //Time since last target spawn
    public GameObject target;
    public GameObject Parent;
    public float difficulty = 5.0f; //The higher the number, the lower the difficulty. The difficulty corresponds to the time between spawns of the target
    public GameHud hud;
    private float score;
    private float timeLastHit = 0.0f;
    private float timeTargetSpawn  = 0.0f;
    private float timeBetweenSpawnAndHit = 0.0f;
    private Dictionary<GameObject, float> targetAgesAndStates = new Dictionary<GameObject, float>();

    private void Start()
    {
        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
        hud.UpdateDifficulty(difficulty);

    }


    public void SetLastHitTime(float time)
    {
        timeLastHit = time;
        timeBetweenSpawnAndHit = timeLastHit - timeTargetSpawn;

        //SETTING THE DIFFICULTY
        if (timeBetweenSpawnAndHit <= difficulty / 3)
        {
            difficulty -= difficulty * 0.1f;
            score = 100 + (100 * difficulty / 10);
        } else
        {
            score = 100;
        }
       

        //Update the UI
        hud.UpdateDifficulty(difficulty);
        hud.UpdateScore(score);
        /*
        Debug.Log("Difficulty : " + difficulty);
        Debug.Log("Time of Last Hit:" + timeLastHit);
        Debug.Log("Time target Spawn:" + timeTargetSpawn);
        Debug.Log("Time between Spawn and Hit:" + timeBetweenSpawnAndHit);
        Debug.Log("Time to hit:" + difficulty / 3);*/
    }

    

    // Update is called once per frame
    void Update()
    {
        


        foreach (GameObject target in new List<GameObject>(targetAgesAndStates.Keys))
        {
            // Update the target's age
            targetAgesAndStates[target] += Time.deltaTime;


            // Check if the target is dead or not
            CheckTargetAlive(target);
        }

        timer += Time.deltaTime;





        if (timer >= difficulty)
        {
            timer = 0.0f; //restart the timer

            //Spawning the target
            GameObject obj = Instantiate(target);
            obj.AddComponent<Target>();
            //obj.transform.localScale
            obj.transform.position = new Vector3(Random.Range(-2, 2), Random.Range(0.5f, 3), transform.position[2]);
            timeTargetSpawn = Time.time;
            // Store the target's age and dead state
            targetAgesAndStates.Add(obj, 0);
            Debug.Log("Targets age at spawn"+targetAgesAndStates[obj]);

        }

    }

    

    void CheckTargetAlive(GameObject target)
    {
        // Check if the target is dead or not
        if (targetAgesAndStates[target] > difficulty) //TODO Change this variable to change the lifetime of the target
        {
            Debug.Log("Target's age:" + targetAgesAndStates[target]);
            difficulty += difficulty * 0.1f;
            score = -100;
            hud.UpdateScore(score);
            hud.UpdateDifficulty(difficulty);
            Destroy(target);
            targetAgesAndStates.Remove(target); // Remove the target from the dictionary
        }
        else
        {
            // Update the target's age and dead state
            targetAgesAndStates[target] += Time.deltaTime;
            if (target.GetComponent<Target>().IsDestroyed())
            {
                targetAgesAndStates[target] = 0.0f;
            }
        }
    }

    public void RemoveTargetFromDictionary(GameObject target)
    {
        if (targetAgesAndStates.ContainsKey(target))
        {
            targetAgesAndStates.Remove(target);
        }
    }

}
