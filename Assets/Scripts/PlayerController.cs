using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField] float movementSpeed = 5f;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jumpForce = 7f;
    bool isGrounded = true;
    float stamina = 5f;
    [SerializeField] public Animator anim;

    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        
        if (direction.x != 0 || direction.z != 0)
        {
            anim.SetBool("Walking", true);
        }
        if (direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("Walking", false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
            anim.SetBool("Jumping", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if(stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
            }
            else
            {
                currentSpeed = movementSpeed;
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {            
            stamina += Time.deltaTime;                      
            currentSpeed = movementSpeed;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.Play("Side Kick");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.Play("High Kick");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.Play("Kick");
        }

        // if (Input.GetKeyDown(KeyCode.LeftControl))
        // {
        //     currentSpeed = 3f;
        //     if (direction.x != 0 || direction.z != 0)
        //     {
        //         anim.SetBool("Sneak", true);
        //     }
        //     if (direction.x == 0 && direction.z == 0)
        //     {
        //         anim.SetBool("Sneak", false);
        //     }
        // }

    }
    
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        anim.SetBool("Jumping", false);
    }
}
