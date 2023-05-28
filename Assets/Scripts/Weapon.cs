using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public Hud hud;
    public UnityEvent OnGunShoot;
    public Camera fpsCam;
    public float range = 100f;
    public float damage = 100;
    public float firerate = 1000.0f;
    private float lastShot = 0f;

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
            if (target != null && Time.time > firerate + lastShot)
            {
                //hud.IncreaseTargetsHit();
                target.TakeDamage(damage);
                lastShot = Time.time;
            }

        }
    }

}
