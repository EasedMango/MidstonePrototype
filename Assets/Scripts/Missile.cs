using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;

    public GameObject Station;
    public GameObject Player;

    Rigidbody rb;

    float distanceToPlayer;
    float distanceToStation;

    Vector3 target;

    // Start is called before the first frame update
    void Awake()
    {
        speed = 10;

        Player = GameObject.Find("Player");
        Station = GameObject.Find("SpaceStation");

        rb = GetComponent<Rigidbody>();

        distanceToStation = Vector3.Distance(transform.position, Station.transform.position);
        distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer < distanceToStation)
        {
            target = Player.transform.position;
        }

        else if (distanceToPlayer > distanceToStation)
        {
            target = Station.transform.position;
        }

        rb.velocity = (target - transform.position).normalized * speed;

        transform.forward = (target - transform.position).normalized;

        transform.rotation *= Quaternion.AngleAxis(90, new Vector3(0, 1, 0));

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
              
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name is "Player")
        {
            Debug.Log("Hit Player");
            Destroy(gameObject);
        }

        if(other.name is "SpaceStation")
        {
            Debug.Log("Hit Station");
            Destroy (gameObject);
        }
    }
}
