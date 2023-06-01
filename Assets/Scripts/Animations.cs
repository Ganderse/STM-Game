using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private float dissolveSpeed = 0.0012f;


    public IEnumerator fadeout()
    {
        Debug.Log("Fading object");

        if (gameObject.GetComponent<MeshRenderer>().material.GetFloat("_Clipping") == 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = GameObject.Find("Sphere").GetComponent<Renderer>().material; 
            for (float i = 0f; i <= 1f; i += dissolveSpeed)
            {
                gameObject.GetComponent<MeshRenderer>().material.SetFloat("_Clipping", i);
                yield return null;
            }
            Destroy(gameObject);
        }

    }

    public void test()
    {
        Debug.Log("test");
    }
}
