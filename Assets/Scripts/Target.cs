using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] // Add this attribute to make the hud variable visible in the Inspector
    public float health = 50f;
    public GameHud hud;

    void Start()
    {
        hud = GameObject.Find("Canvas").GetComponent<GameHud>();
    }

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
        hud.IncreaseTargetsHit();


        Debug.Log(hud.timeVar);



        Destroy(gameObject);
    }
    
}
