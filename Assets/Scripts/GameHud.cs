using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameHud : MonoBehaviour
{

    /*
    public UnityEvent OnGunShoot;
    [SerializeField] Camera cam;
    public float range = 100f;
    public float damage = 100;
    public float firerate = 1000.0f;
    private float lastShot = 0f;
    */

    //UI Text GameObjects
    public GameObject targets;
    //public UnityEngine.UI.Text targetsHitText;

    //Game Variable
    private float targetsHit = 0f;

    //Text Components
    TextMeshProUGUI targetsHitText;

    // Start is called before the first frame update

    private void Start()
    {
        targetsHitText = targets.GetComponent<TextMeshProUGUI>();
        UpdateHUD();
    }



    //TRYING TO SHOOT A SECOND RAY A THE SAME TIME TO SEE IF THERE IS A COLISION IN WHICH CASE INCREASE TARGET HITS COUNT
    /*
    
    void Update()
    {
        //Only activates on key press
        if (Input.GetMouseButtonDown(0))
        //if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hitinfo;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f)); //Envoie de laser
        if (Physics.Raycast(ray, out hitinfo, range))
        {
            Target target = hitinfo.transform.GetComponent<Target>();
            if (target != null && Time.time > firerate + lastShot)
            {
                IncreaseTargetsHit();
                //target.TakeDamage(damage);
                lastShot = Time.time;
            }

        }
    }*/


    private void UpdateHUD()
    {

        //targetsssHit = targetsHit.ToString();
        targetsHitText.text = "Targets Hit:" + targetsHit.ToString();
        Debug.Log(targetsHit.ToString());
    }

    public void IncreaseTargetsHit()
    {
        targetsHit++;
        UpdateHUD();
    }

    public void test()
    {
        Debug.Log("test()");
    }



}
