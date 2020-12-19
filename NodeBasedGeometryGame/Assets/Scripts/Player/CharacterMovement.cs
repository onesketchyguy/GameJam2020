using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpSpeed = 5;
    public Rigidbody2D rigidBody;

    public float groundCheckOffset = 0.1f;
    public float groundCheckDistance = 0.2f;
    public LayerMask ground;

    [Range(0.001f, 1)]
    public float CoyoteTime = 0.24f;

    private float coyoteTime = 1;

    private Vector3 input;

    private void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical"), 1);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        bool grounded = GroundCheck() && coyoteTime > 0; // Debugs every frame, helpful for debugging if grounded.

        if (coyoteTime > 0) coyoteTime -= Time.deltaTime;

        Vector3 velocity = rigidBody.velocity;

        if (input.y != 0 && grounded) velocity.y = jumpSpeed;

        velocity.x = input.x * Time.deltaTime;
        rigidBody.velocity = velocity;
    }

    public bool GroundCheck()
    {
        bool grounded = false;

        int rayCount = 4;

        for (int i = 0; i < rayCount; i++)
        {
            var offset = (Vector3.right * 0.1f * rayCount / 2) - (Vector3.right * 0.1f * i);

            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position + offset - Vector3.up * groundCheckOffset, -Vector3.up, groundCheckDistance, ground);

            Debug.DrawRay(transform.position + offset - Vector3.up * groundCheckOffset, -Vector3.up * groundCheckDistance, (hitInfo.transform != null) ? Color.blue : Color.red);

            grounded = grounded ? grounded : (hitInfo.transform != null);
        }

        coyoteTime = grounded ? CoyoteTime : coyoteTime;

        return grounded;
    }
}