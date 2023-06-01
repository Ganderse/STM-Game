using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public GameHud hud;
    public ReflexSpawner spawner;
    public Camera fpsCam;
    public AudioSource source;
    public AudioClip clip;
    public float range = 100f;
    public float damage = 100;
    public float firerate = 0.05f;   //1 second between shots
    private float lastShot = 0f;


    private void Start()
    {
        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
    }

    // Update is called once per frame
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
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitinfo, range))
        {
            Target target = hitinfo.transform.GetComponent<Target>();
            //Debug.Log(target);
            if (target != null && Time.time > firerate + lastShot)
            {
                target.TakeDamage(damage);
                source.PlayOneShot(clip);
                lastShot = Time.time;
                spawner.SetLastHitTime(lastShot);
            }


        }
    }

}
