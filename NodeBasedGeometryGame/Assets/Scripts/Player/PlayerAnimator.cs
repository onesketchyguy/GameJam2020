using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public CharacterMovement controller;

    public SpriteRenderer _renderer;

    private const float WEIGHT = 0.1f;

    private bool biting;

    private void Update()
    {
        if (controller.rigidBody.velocity.x > WEIGHT)
            _renderer.flipX = false;
        else if (controller.rigidBody.velocity.x < -WEIGHT)
            _renderer.flipX = true;

        if (controller.rigidBody.velocity.y > -WEIGHT &&
            controller.rigidBody.velocity.y < WEIGHT &&
            !controller.grounded)
        {
            biting = true;
        }
        else
        {
            biting = false;
        }

        animator.SetBool("Biting", biting);

        animator.SetFloat("SpeedX", Mathf.Abs(controller.rigidBody.velocity.x));
        animator.SetFloat("SpeedY", controller.rigidBody.velocity.y);
    }
}