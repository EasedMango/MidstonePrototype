using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public float health;

    public GameObject SpaceStation;
    float distanceToStation;
    public float stationDamageRange;

    public GameObject Player;
    float distanceToPlayer;
    public float playerDetectionRange;
    public float playerDamageRange;

    public GameObject Missile;
    public float fireRate;
    public float nextFire;
    public float projectileSpeed;    

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
        SpaceStation = GameObject.Find("SpaceStation");

        speed = 2;
        health = 10;

        stationDamageRange = 15;

        playerDetectionRange = 20;
        playerDamageRange = 10;

        fireRate = 1;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToStation = Vector3.Distance(transform.position, SpaceStation.transform.position);
        distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        var step = speed * Time.deltaTime;

        if(distanceToPlayer > playerDamageRange && distanceToPlayer <= playerDetectionRange && distanceToStation > distanceToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        }

        else if(distanceToStation > stationDamageRange && distanceToPlayer > playerDamageRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, SpaceStation.transform.position, step);
        }

        if(distanceToPlayer <= playerDamageRange || distanceToStation <= stationDamageRange)
        {
            CheckToFire();
        }       
        
        if(health <= 0)
        {
            FindObjectOfType<AudioController>().Play("Explosion"); 
            Destroy(gameObject);
        }
    }

    void CheckToFire()
    {
        if(Time.time > nextFire)
        {
            Instantiate(Missile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag is "PlayerMissile")
        {
            TakeDamage();
        }
        
    }

    void TakeDamage()
    {
        health -= 5;
    }
}
