using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] public ParticleSystem SparkEffectobject = null;
    private float speed = 9.8f;
    private float jumpPower = 11.2f;
    public bool isGrounded = false;
    private bool wantsToJump = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        addForce();

        if (wantsToJump && isGrounded)
        {
            
            Jump();
            wantsToJump = false; // Reset the jump flag
        }

        if (isGrounded)
        {


            Quaternion rot = transform.rotation;

            rot.z = Mathf.Round(rot.z / 90) * 90;
            transform.rotation = rot;
            if (Input.GetKey(KeyCode.Space))
            {
                wantsToJump = true;
                rb.velocity = Vector3.zero;
                // Rotate the player when jumping
                //transform.rotation = Quaternion.Euler(0f, 0f, 180);
            }
        }
        else
        {
            transform.Rotate(Vector3.forward * 375f * Time.deltaTime);
        }

    }

    void Jump()
    {

        SparkEffectobject.Stop();
        rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
        isGrounded = false;
    }
    public void Collect()
    {
        SparkEffectobject.Play();
    }
    /*
    void Jump()
{
    if(isGrounded)
    {
        Quaternion rot = transform.rotation;

        rot.z = Mathf.Round(rot.z / 90) * 90;
        transform. rotation = rot;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector2.up * 5500);
        }
    }
    else
    {
        transform.Rotate(Vector3.back * 5f);
    }
}*/

    void addForce()
    {
        float moveVertical = rb.velocity.y; // Preserve the vertical velocity for jumping

        Vector3 movement = new Vector3(-speed, moveVertical, 0f);
        rb.velocity = movement;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            Collect();
            isGrounded = true;
        }
    }
    /*
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    */
}

