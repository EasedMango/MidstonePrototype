using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
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

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        origin = (transform.position - (transform.up * 0.5f));
        vert = Input.GetAxisRaw("Vertical");
        hor = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKey(KeyCode.Space);
        down = Input.GetKey(KeyCode.C);


    }
    void Movement()
    {

        //frwd += up * 0.25f;


        Vector3 fNet = Vector3.zero;
        // print(vert);
        //  print(hor);
        if (vert > 0)
        {

            fNet += transform.forward;
        }
        if (vert < 0)
        {

            fNet -= transform.forward;
        }
        if (hor > 0)
        {

            fNet -= transform.right;

        }
        if (hor < 0)
        {

            fNet += transform.right;
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


}
