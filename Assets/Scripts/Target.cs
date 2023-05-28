using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] // Add this attribute to make the hud variable visible in the Inspector
    public Hud hud;
    public float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    //User has shot the target
    void Die()
    {
        //hud.GetComponent<Hud>().IncreaseTargetsHit();
        //hud.IncreaseTargetsHit();
        Destroy(gameObject);
    }
    
}
