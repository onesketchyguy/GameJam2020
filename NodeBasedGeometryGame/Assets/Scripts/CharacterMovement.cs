using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpSpeed = 5;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal")*speed,Input.GetAxis("Vertical"),1);
        Vector3 velocity = rigidBody.velocity;
        if (input.y !=0)
        {
            rigidBody.AddForce(Vector2.up * jumpSpeed);
        }


        velocity.x = input.x * Time.deltaTime;
        rigidBody.velocity = velocity;

    }
}
