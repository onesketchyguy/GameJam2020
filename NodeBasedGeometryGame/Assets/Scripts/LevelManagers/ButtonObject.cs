using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ButtonObject : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite downSprite, upSprite;

    [Tooltip("This item can trigger more than once.")]
    public bool MultipleTrigger = false;

    public UnityEngine.Events.UnityEvent OnTriggered;

    private bool hasTriggered = false;

    private void Start()
    {
        spriteRenderer.sprite = upSprite;
    }

    private void OnCollisionEnter2D()
    {
        spriteRenderer.sprite = downSprite;

        if (Time.timeSinceLevelLoad < 1) return;

        if (hasTriggered && !MultipleTrigger) return;

        OnTriggered?.Invoke();
        hasTriggered = true;
    }

    private void OnCollisionExit2D() => spriteRenderer.sprite = upSprite;
}