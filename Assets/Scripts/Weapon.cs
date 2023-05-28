using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public Camera fpsCam;
    public float range = 100f;
    public float damage = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
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
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            Debug.Log(hitinfo.transform.name);
        }
    }

}
