using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    public float speed;

    Rigidbody rb;

    Transform player;
    
    // Start is called before the first frame update
    void Awake()
    {
        speed = 10;

        rb = GetComponent<Rigidbody>();

        player = GameObject.Find("Player").transform;
        rb.velocity = -(player.forward).normalized * speed;
        transform.forward = -player.forward;
        transform.rotation *= Quaternion.AngleAxis(90, new Vector3(0, 1, 0));

        Destroy(gameObject, 5);
    }

    private void Start()
    {
        FindObjectOfType<AudioController>().Play("Missile");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag is "Enemy")
        {
            Debug.Log("Hit Enemy");
            Destroy(gameObject);
        }
    }
}
