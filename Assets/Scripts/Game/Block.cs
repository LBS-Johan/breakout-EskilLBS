using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float maxHealth;
    float health;

    [Space]

    [SerializeField] bool baseGradientOnMaxHealth;
    [SerializeField] float gradientDivider;
    [SerializeField] Gradient healthColorGradient;
    SpriteRenderer spriteRenderer;

    [Space]

    [SerializeField] bool dropPowerUp;
    [SerializeField] List<GameObject> powerUps;
    [SerializeField] int oneInXPowerUpChance;

    [Space]

    public int blockID;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = healthColorGradient.Evaluate(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (baseGradientOnMaxHealth)
        {
            spriteRenderer.color = healthColorGradient.Evaluate(health / maxHealth);
        }
        else
        {
            spriteRenderer.color = healthColorGradient.Evaluate(health / gradientDivider);
        }
        

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (dropPowerUp)
        {
            if(Random.Range(0, oneInXPowerUpChance) == 0)
            {
                Instantiate(powerUps[Random.Range(0, powerUps.Count)], transform.position, Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }
}
