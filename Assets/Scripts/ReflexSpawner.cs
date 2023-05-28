using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexSpawner : MonoBehaviour
{
    public float timer = 0.0f; //Time since last target spawn
    public GameObject target;
    public GameObject Parent;
    public float difficulty = 5.0f; //The higher the number, the lower the difficulty. The difficulty corresponds to the time between spawns of the target
    public GameHud hud;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= difficulty)
        {
            timer = 0.0f; //restart the timer

            //Spawning the target
            GameObject obj = Instantiate(target);
            obj.AddComponent<Target>();
            obj.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(0.5f, 4), transform.position[2]);


            //Life duration of the object
            Destroy(obj, difficulty / 2);
        }
        
    }
}
