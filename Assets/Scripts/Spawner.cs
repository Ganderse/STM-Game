using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject target;
    public bool testBool = true;
    // Update is called once per frame
    void Update()
    {


     if(Input.GetKeyDown(KeyCode.Space))
     {

            var obj = Instantiate(target);
            obj.transform.position = new Vector3(Random.Range(-3, 3), Random.Range(0, 4), transform.position[2]);

            //Instantiate(target,transform.position, Quaternion.identity);
     }   
    }
}
