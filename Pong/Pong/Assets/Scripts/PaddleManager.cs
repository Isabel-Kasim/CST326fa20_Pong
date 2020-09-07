using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    public Rigidbody rb_right;
    public Rigidbody rb_left;
    public float speed = 10.0f;
    private Vector3 rmovement;
    private Vector3 lmovement;
    private KeyCode moveUp = KeyCode.A;
    // Start is called before the first frame update
    void Start()
    {
        rb_right = rb_right.GetComponent<Rigidbody>();
        rb_left = rb_left.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rmovement = new Vector3(0, 0, Input.GetAxis("RPaddle"));
        //lmovement = new Vector3(0, 0, Input.GetAxis("LPaddle"));

    }

    void FixedUpdate()
    {
        PaddleMovement(rmovement, lmovement);
    }

    void PaddleMovement(Vector3 rdirection, Vector3 ldirection)
    {
        rb_right.MovePosition(transform.position + (rdirection * speed * Time.deltaTime));
        rb_left.MovePosition(transform.position + (ldirection * speed * Time.deltaTime));

    }

    void OnCollisionEnter(Collision collision)
    {
        rb_right.constraints = RigidbodyConstraints.FreezeAll;
        rb_left.constraints = RigidbodyConstraints.FreezeAll;
    }
    void OnCollisionExit(Collision collision)
    {
        rb_right.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        rb_left.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}
