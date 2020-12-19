using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public CharacterMovement controller;

    public SpriteRenderer renderer;

    private const float WEIGHT = 0.1f;

    private void Update()
    {
        if (controller.rigidBody.velocity.x > WEIGHT)
            renderer.flipX = false;
        else if (controller.rigidBody.velocity.x < -WEIGHT)
            renderer.flipX = true;

        animator.SetFloat("SpeedX", Mathf.Abs(controller.rigidBody.velocity.x));
        animator.SetFloat("SpeedY", controller.rigidBody.velocity.y);
    }
}