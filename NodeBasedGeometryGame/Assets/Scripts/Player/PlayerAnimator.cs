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

        if (controller.rigidBody.velocity.y == 0)
        {
            biting = true;
        }

        animator.SetBool("Biting", biting);

        animator.SetFloat("SpeedX", Mathf.Abs(controller.rigidBody.velocity.x));
        animator.SetFloat("SpeedY", controller.rigidBody.velocity.y);
    }
}