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
    bool brake;
    public LayerMask mask;
    Vector3 origin;

    //public float health;
    public int maxHealth = 50;
    public int currentHealth;

    public GameObject PlayerMissile;
    public float fireRate;
    public float nextFire;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //health = 50;
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        fireRate = 1;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        origin = (transform.position - (transform.up * 0.5f));
        vert = Input.GetAxisRaw("Vertical");
        hor = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey(KeyCode.Space);
        down = Input.GetKey(KeyCode.LeftControl);
        brake = Input.GetKey(KeyCode.LeftShift);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(3);
        }

        if (Input.GetMouseButtonDown(0))
        {
            CheckToFire();
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
        if (brake)
        {
            fNet = -rb.velocity;
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
       currentHealth -= 5;

        healthBar.SetHealth(currentHealth);
    }

    void TakeAsteroidDamage()
    {

    }

    void CheckToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(PlayerMissile, transform.position - (transform.forward * 2), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
