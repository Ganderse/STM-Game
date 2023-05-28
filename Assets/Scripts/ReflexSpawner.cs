using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexSpawner : MonoBehaviour
{
    public float timer = 0.0f; //Time since last target spawn
    public GameObject target;
    public float difficulty = 5.0f; //The higher the number, the lower the difficulty. The difficulty corresponds to the time between spawns of the target

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= difficulty)
        {
            timer = 0.0f; //restart the timer

            var obj = Instantiate(target);
            obj.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(0, 4), transform.position[2]);
        }
        
    }
}
