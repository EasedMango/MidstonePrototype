using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Camera))]
public class Character : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1;
    float vert, hor;
    bool jump;
    bool down;
    public LayerMask mask;
    Vector3 origin;

    public float health;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        health = 50;
    }

    // Update is called once per frame
    void Update()
    {
        origin = (transform.position - (transform.up * 0.5f));
        vert = Input.GetAxisRaw("Vertical");
        hor = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey(KeyCode.Space);
        down = Input.GetKey(KeyCode.C);

        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }
    }
    void Movement()
    {

        //frwd += up * 0.25f;


        Vector3 fNet = Vector3.zero;
        // print(vert);
        //  print(hor);
        if (vert > 0)
        {

            fNet -= transform.forward;
        }
        if (vert < 0)
        {

            fNet += transform.forward;
        }
        if (hor > 0)
        {

            fNet -= transform.right;

        }
        if (hor < 0)
        {

            fNet += transform.right;
        }
        if (jump)
        {
            fNet += transform.up;
        }
        if (down)
        {
            fNet -= transform.up;
        }


        rb.velocity += Vector3.ClampMagnitude(fNet.normalized * speed, 10);

    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag is "Missile")
        {
            TakeMissileDamage();
        }
    }

    void TakeMissileDamage()
    {
        health -= 5;
    }

    void TakeAsteroidDamage()
    {

    }
}
