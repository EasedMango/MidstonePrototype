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


        if (rb.velocity.magnitude < 5)
        {
            rb.velocity += Vector3.ClampMagnitude(fNet.normalized * speed, 10);
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void OnDrawGizmos()
    {

        //mesh.vertices = corners;
        //  DrawMesh();
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;




        void DrawRayNormal(Vector3 pos, Vector3 dir) => Handles.DrawAAPolyLine(EditorGUIUtility.whiteTexture, 8f, pos, pos + dir);

        void DrawRay(Vector3 pos, Vector3 dir) => Handles.DrawAAPolyLine(EditorGUIUtility.whiteTexture, 8f, pos, dir);
        DrawRayNormal(origin, Vector3.down);
        if (Physics.Raycast(headPos - (transform.up * 0.25f), Vector3.down, out RaycastHit hit, mask))
        {


            Vector3 hitPos = hit.point;
            Vector3 up = hit.normal;
            Vector3 right = Vector3.Cross(up, lookDir).normalized;
            Vector3 forward = Vector3.Cross(right, up);
            //  forward += up * 0.25f;

            Handles.color = Color.green;
            DrawRayNormal(transform.position, up);
            Handles.color = Color.red;
            DrawRayNormal(transform.position, right);
            Handles.color = Color.cyan;
            DrawRayNormal(transform.position, forward);


        }
        else
        {
            Handles.color = Color.red;
            DrawRayNormal(headPos, lookDir);
        }

    }
}
