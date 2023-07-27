using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;

    [SerializeField] float movemSpeed;
    float startSpeed;
    [SerializeField] float sprint;

    public Transform LookingAt;

    Vector3 moveMontDirection;

    Rigidbody rb;


    public float playerheight;
    public LayerMask whatIsGround;
    bool isOnGround;

    public float groundDrag;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        startSpeed = movemSpeed;

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        
            movemSpeed = startSpeed;



        rb.drag = groundDrag;

        speedControl();
    }

    private void FixedUpdate()
    {
        moveMontDirection = LookingAt.forward * vertical + LookingAt.right * horizontal;

        rb.AddForce(moveMontDirection.normalized * movemSpeed * 10f, ForceMode.Force);
    }

    private void speedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > movemSpeed)
        {
            Vector3 limetedVel = flatVel.normalized * movemSpeed;
            rb.velocity = new Vector3(limetedVel.x, rb.velocity.y, limetedVel.z);
        }
    }
}
