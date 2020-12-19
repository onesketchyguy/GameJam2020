using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal")*speed,1,1);
        Vector3 velocity = new Vector3();
        velocity.x += input.x * Time.deltaTime;
        transform.position += velocity;

    }
}
