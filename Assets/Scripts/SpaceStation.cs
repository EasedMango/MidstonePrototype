using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceStation : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
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
        health -= 5;
    }
}
