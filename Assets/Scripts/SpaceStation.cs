using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceStation : MonoBehaviour
{
    public float health;
    public int maxHealth = 50;
    public int currentHealth;

    public HealthBarSS healthBarSS;

    // Start is called before the first frame update
    void Start()
    {
        //health = 50;
        currentHealth = maxHealth;

        healthBarSS.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag is "Missile")
        {
            TakeMissileDamage();
        }
    }

    void TakeMissileDamage()
    {
        currentHealth -= 5;

        healthBarSS.SetHealth(currentHealth);
    }
}
