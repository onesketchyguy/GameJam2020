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

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        coyoteTime -= Time.deltaTime;

        Vector3 input = new Vector3(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical"), 1);
        Vector3 velocity = rigidBody.velocity;

        if (input.y != 0 && GroundCheck()) velocity.y = jumpSpeed;

        velocity.x = input.x * Time.deltaTime;
        rigidBody.velocity = velocity;
    }

    private bool GroundCheck()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position - Vector3.up * groundCheckOffset, -Vector3.up, groundCheckDistance, ground);

        coyoteTime = (hitInfo.transform != null) ? CoyoteTime : coyoteTime;

        return (hitInfo.transform != null);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = GroundCheck() ? Color.white : Color.red;

        var start = transform.position - Vector3.up * groundCheckOffset;

        Gizmos.DrawLine(start, start - Vector3.up * groundCheckDistance);
    }
}